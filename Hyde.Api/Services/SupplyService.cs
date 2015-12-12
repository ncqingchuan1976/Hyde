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

        public OperateReult<supplyDto> AddSupply(supplyDto item)
        {

            _SupplyRepo.Add(item);

            _SupplyRepo.UnitOfWork.Save();

            return new OperateReult<supplyDto>(true);

        }

        public IPagedList<supplyDto> GetSupplyList(PageCommand Page, string Name = null, string Code = null, bool? ShutOut = default(bool?))
        {

            var query = _SupplyRepo.Find();

            if (!string.IsNullOrWhiteSpace(Name))
                query = query.Where(t => t.name.StartsWith(Name));

            if (!string.IsNullOrWhiteSpace(Code))
                query = query.Where(t => t.code.StartsWith(Code));

            if (ShutOut.HasValue)
                query = query.Where(t => t.shutout == ShutOut);

            return query.OrderBy(t => t.key).AsNoTracking().ToPagedList(Page.PageIndex, Page.PageSize);

        }
    }
}
