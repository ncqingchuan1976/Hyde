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

        public OperationResult<supplyDto> AddSupply(supplyDto item)
        {

            _SupplyRepo.Add(item);

            _SupplyRepo.UnitOfWork.Save();

            return new OperationResult<supplyDto>(true) { Entity = item };

        }

        public OperationResult<supplyDto> DeleteSupply(int Key)
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

        public OperationResult<supplyDto> EditSupply(supplyDto item)
        {
            _SupplyRepo.ChangeState(item, EntityState.Unchanged);
            _SupplyRepo.Edit(item, nameof(item.name), nameof(item.remark), nameof(item.shutout), nameof(item.priorlevel));
            _SupplyRepo.UnitOfWork.Save();
            return new OperationResult<supplyDto>(true);
        }

        public supplyDto FindSingle(int Key)
        {
            return _SupplyRepo.FindSingle(Key);
        }

        public IPagedList<supplyDto> GetSupplyList(int PageIndex, int PageSize, string Name = null, string Code = null, bool? ShutOut = default(bool?))
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


    }
}
