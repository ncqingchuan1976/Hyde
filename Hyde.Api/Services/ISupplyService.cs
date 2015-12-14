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

        supplyDto Create();

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="item">供应商实体</param>
        /// <returns></returns>
        OperationResult<supplyDto> Add(supplyDto item);
        /// <summary>
        /// 根据条件查询并返回供应商列表，带分页
        /// </summary>
        /// <param name="PageIndex">页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="Name">名称</param>
        /// <param name="Code">编码</param>
        /// <param name="ShutOut">停用</param>
        /// <returns>供应商列表</returns>
        IPagedList<supplyDto> Find(int PageIndex, int PageSize, string Name = null, string Code = null, bool? ShutOut = null);

        OperationResult<supplyDto> Edit(supplyDto item);

        OperationResult<supplyDto> Delete(supplyDto item);

        OperationResult<IEnumerable<int>> Delete(int[] Keys);

        supplyDto FindSingle(int Key);
    }
}
