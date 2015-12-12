using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Hyde.Api.Model.RequestCommands;
using Hyde.Api.Model.RequestModels;
using Hyde.Api.Models;
using Hyde.Domain.Model;
using PagedList;
namespace Hyde.Api.Services
{
    public interface ISupplyService
    {
        OperateReult<supplyDto> AddSupply(supplyDto item);

        IPagedList<supplyDto> GetSupplyList(PageCommand Page, string Name = null, string Code = null, bool? ShutOut = null);

    }
}
