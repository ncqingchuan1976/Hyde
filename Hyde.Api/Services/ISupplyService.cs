using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Hyde.Api.Models.RequestModels;
using Hyde.Api.Models.ResultModels;
using Hyde.Domain.Model;
using PagedList;
namespace Hyde.Api.Services

{
    /// <summary>
    /// 供应商操作接口
    /// </summary>
    public interface ISupplyService : IService
    {
        /// <summary>
        /// 创建一个供应商
        /// </summary>
        /// <returns></returns>

        supplyDto Create();

        /// <summary>
        /// 添加供应商
        /// </summary>
        /// <param name="item">供应商实体</param>
        /// <returns></returns>
        OperationResult<string> Add(supplyDto item);
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
        /// <summary>
        /// 编辑供应商
        /// </summary>
        /// <param name="item">需要编辑的供应商资料</param>
        /// <returns>返回编辑后的供应商</returns>
        OperationResult<string> Edit(supplyDto item);

        OperationResult<string> Delete(supplyDto item);

        OperationResult<IEnumerable<int>> Delete(int[] Keys);

        supplyDto FindSingle(int Key);
    }
}
