using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External;
using Hyde.External.Sanfenqiu;
using Hyde.Result.Operation;
namespace Hyde.External.Sanfenqiu
{
    /// <summary>
    /// 三分球系统对接操作接口
    /// </summary>
    public interface ISanfenqiu : IExternal
    {
        /// <summary>
        /// 根据条件获取三分球系统商品列表
        /// </summary>
        /// <param name="sign">apikey</param>
        /// <param name="page">分页页号</param>
        /// <param name="page_num">分页大小</param>
        /// <param name="product_ids">商品ID集合用","分割 如 1,2,3</param>
        /// <param name="goods_code">商品货号</param>
        /// <param name="name">商品名称</param>
        /// <param name="is_pic">是否有主图 0:有，1:无</param>
        /// <param name="datebegin">上市日期</param>
        /// <returns>返回查询到的商品列表</returns>
        OperationResult<responseSanfenqiuProduct> GetProductList(string sign, int? page = null, int? page_num = null, string product_ids = null, string goods_code = null, string name = null, int? is_pic = null, string datebegin = null);
        /// <summary>
        /// 获取三分球商品分类列表
        /// </summary>
        /// <param name="sign">apikey</param>
        /// <param name="cat_ids">分类ID集合用","分割，如:1,2,3</param>
        /// <returns>返回查询到的商品分类列表</returns>
        OperationResult<responseSanfenqiuCatalogList> GetCatalogList(string sign, string cat_ids);
        /// <summary>
        /// 根据查询条件返回类别列表
        /// </summary>
        /// <param name="sign">apikey</param>
        /// <param name="cat_id">类别ID</param>
        /// <returns>返回该类别及其下一级类别</returns>
        OperationResult<responseSanfenqiuCatalog> GetCatalog(string sign, int cat_id);
        /// <summary>
        /// 取得商品品牌列表
        /// </summary>
        /// <param name="sign">申请获得 app_secret</param>
        /// <param name="brand_ids">商品品牌ID，用“,”分割，例如：brand_ids = 1,2,3</param>
        /// <returns>商品品牌列表</returns>
        OperationResult<responseSanenqiuBrandList> GetBrandList(string sign, string brand_ids);
        /// <summary>
        /// 取得单个商品品牌
        /// </summary>
        /// <param name="sign">申请获得 app_secret</param>
        /// <param name="brand_id">商品品牌ID，例如：brand_id = 120</param>
        /// <returns>单个商品品牌</returns>
        OperationResult<responseSanfenqiuBrand> GetBrand(string sign, int brand_id);
        /// <summary>
        /// 获取商品库存信息
        /// </summary>
        /// <param name="sign">申请获得 app_secret</param>
        /// <param name="product_id">商品ID</param>
        /// <returns>商品库存信息</returns>
        OperationResult<responseSanfenqiuStock> GetStock(string sign, int product_id);
        /// <summary>
        /// 获取区域列表，根据区域编号，区域名称查询区域信息
        /// </summary>
        /// <param name="sign">申请获得 app_secret</param>
        /// <param name="area_id">区域编码：如 “北京” 区域编码 ：110000，非必选</param>
        /// <param name="area_name">区域名称：如 “海淀区”,非必选</param>
        /// <returns>区域列表</returns>
        OperationResult<responseSanfenqiuArea> GetArea(string sign, int? area_id = null, string area_name = null);
        /// <summary>
        /// 根据查询条件返回订单列表
        /// </summary>
        /// <param name="sign">申请获得 app_secret </param>
        /// <param name="page">分页页数</param>
        /// <param name="page_num">每页订单数量 默认 20</param>
        /// <param name="order_ids">订单ID，用“,”分割，例如：order_ids = 1001,1002,1003</param>
        /// <param name="order_sns">订单号，用“,”分割，例如：order_sns = N1001,N1002,N1003</param>
        /// <param name="other_order_sn">外部订单号</param>
        /// <param name="consignee">收货人</param>
        /// <param name="mobile">手机</param>
        /// <param name="fromtime">订单开始时间</param>
        /// <returns>订单列表</returns>
        OperationResult<responseSanfenqiuOrder> GetOrderList(string sign, int? page = null, int? page_num = null, string order_ids = null, string order_sns = null, string other_order_sn = null, string consignee = null, string mobile = null, int? fromtime = null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        OperationResult<responseSanfenqiuStockChange> GetStockChange(string sign, string starttime = null, string endtime = null);

    }
}
