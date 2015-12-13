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
    public interface ISupplyService :IService
    {
        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="item">供应商实体</param>
        /// <returns></returns>
        OperationResult<supplyDto> AddSupply(supplyDto item);

        IPagedList<supplyDto> GetSupplyList(int PageIndex, int PageSize, string Name = null, string Code = null, bool? ShutOut = null);

        OperationResult<supplyDto> EditSupply(supplyDto item);

        OperationResult<supplyDto> DeleteSupply(int Key);

        supplyDto FindSingle(int Key);
    }
}
