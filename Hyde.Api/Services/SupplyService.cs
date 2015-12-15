using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Models.ResultModels;
using Hyde.Repository;
using Hyde.Domain.Model;
using PagedList;
using System.Data.Entity;
namespace Hyde.Api.Services
{
    public class SupplyService : ISupplyService
    {
        private int Save()
        {
            return _SupplyRepo.UnitOfWork.Save();
        }

        readonly IRepository<supplyDto> _SupplyRepo;

        public SupplyService(IRepository<supplyDto> SupplyRepo)
        {
            _SupplyRepo = SupplyRepo;
        }

        public OperationResult<string> Add(supplyDto item)
        {
            if (_SupplyRepo.Exist(t => t.code == item.code))
            {
                return new OperationResult<string>(errstate.code_already_exist, errstate.code_already_exist.ToString())
                {
                    Entity = item.code
                };
            }
            if (_SupplyRepo.Exist(t => t.priorlevel == item.priorlevel))
            {
                return new OperationResult<string>(errstate.supply_priorlevel_already_exist, errstate.supply_priorlevel_already_exist.ToString())
                {
                    Entity = item.priorlevel.ToString()
                };
            }

            _SupplyRepo.Add(item);

            Save();

            return new OperationResult<string>(errstate.success, errstate.success.ToString()) { Entity = item.key.ToString() };

        }

        public OperationResult<string> Delete(supplyDto item)
        {
            _SupplyRepo.Delete(item);

            try
            {
                Save();
                return new OperationResult<string>(errstate.success, errstate.success.ToString()) { Entity = null };
            }
            catch (Exception ex)
            {
                return new OperationResult<string>(errstate.system_err, errstate.system_err.ToString()) { Entity = ex.Message };
            }

        }

        public OperationResult<string> Edit(supplyDto item)
        {
            var Dto = FindSingle(item.key);

            if (Dto == null)
            {
                return new OperationResult<string>(errstate.key_not_found, errstate.key_not_found.ToString())
                {
                    Entity = item.key.ToString()
                };
            }
            else
            {
                if (item.priorlevel != Dto.priorlevel)
                {
                    if (_SupplyRepo.Exist(t => t.priorlevel == item.priorlevel))
                    {
                        return new OperationResult<string>(errstate.supply_priorlevel_already_exist, errstate.supply_priorlevel_already_exist.ToString())
                        {
                            Entity = item.priorlevel.ToString()
                        };
                    }
                }
            }
            Dto.name = item.name;
            Dto.remark = item.remark;
            Dto.shutout = item.shutout;
            Dto.priorlevel = item.priorlevel;
            Save();
            return new OperationResult<string>(errstate.success, errstate.success.ToString());
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
                return new OperationResult<IEnumerable<int>>(errstate.not_in_range, errstate.not_in_range.ToString()) { Entity = result };

            _SupplyRepo.Remove(list);

            Save();

            return new OperationResult<IEnumerable<int>>(errstate.success, errstate.success.ToString());
        }
        public supplyDto Create()
        {
            return _SupplyRepo.Create();
        }
    }
}
