using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Models;
using Hyde.Api.Model.RequestModels;
using Hyde.Api.Model.RequestCommands;
using Hyde.Repository;
using Hyde.Domain.Model;
using PagedList;
using System.Data.Entity;
namespace Hyde.Api.Services
{
    public class SupplyService : ISupplyService
    {

        readonly IRepository<supplyDto> _SupplyRepo;

        public SupplyService(IRepository<supplyDto> SupplyRepo)
        {
            _SupplyRepo = SupplyRepo;
        }

        public OperationResult<supplyDto> Add(supplyDto item)
        {

            _SupplyRepo.Add(item);

            _SupplyRepo.UnitOfWork.Save();

            return new OperationResult<supplyDto>(true) { Entity = item };

        }



        public OperationResult<supplyDto> Delete(int Key)
        {
            var Dto = FindSingle(Key);
            if (Dto == null)
            {
                return new OperationResult<supplyDto>(false);
            }

            _SupplyRepo.Remove(Dto);
            _SupplyRepo.UnitOfWork.Save();
            return new OperationResult<supplyDto>(true) { Entity = Dto };
        }

        public OperationResult<supplyDto> Edit(supplyDto item)
        {
            var Dto = FindSingle(item.key);
            if (Dto == null)
                return new OperationResult<supplyDto>(false);
            Dto.name = item.name;
            Dto.remark = item.remark;
            Dto.priorlevel = item.priorlevel;
            Dto.shutout = item.shutout;
            _SupplyRepo.UnitOfWork.Save();
            return new OperationResult<supplyDto>(true) { Entity = item };
        }

        public supplyDto FindSingle(int Key)
        {
            return _SupplyRepo.FindSingle(Key);
        }

        public IPagedList<supplyDto> Find(int PageIndex, int PageSize, string Name = null, string Code = null, bool? ShutOut = default(bool?))
        {

            var query = _SupplyRepo.Find();

            if (!string.IsNullOrWhiteSpace(Name))
                query = query.Where(t => t.name.StartsWith(Name));

            if (!string.IsNullOrWhiteSpace(Code))
                query = query.Where(t => t.code.StartsWith(Code));

            if (ShutOut.HasValue)
                query = query.Where(t => t.shutout == ShutOut);

            return query.OrderBy(t => t.key).AsNoTracking().ToPagedList(PageIndex, PageSize);

        }

        public OperationResult<IEnumerable<int>> Delete(int[] Keys)
        {
            var list = _SupplyRepo.Find(t => Keys.Contains(t.key)).ToList();
            var result = Keys.GroupJoin(list, t => t, o => o.key, (p, g) => new { p, g }).SelectMany(t => t.g.DefaultIfEmpty(), (p, x) => new { p.p, q = x == null ? 0 : x.key }).Where(t => t.q == 0).Select(t => t.p);
            if (result.Count() > 0)
                return new OperationResult<IEnumerable<int>>(false) { Entity = result };
            _SupplyRepo.Remove(list);
            _SupplyRepo.UnitOfWork.Save();

            return new OperationResult<IEnumerable<int>>(true);
        }
    }
}
