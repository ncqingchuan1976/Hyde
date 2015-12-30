using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External;
using Hyde.External.Sanfenqiu;
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
        operateResult<responseSanfenqiuProduct> GetProductList(string sign, int? page = null, int? page_num = null, string product_ids = null, string goods_code = null, string name = null, int? is_pic = null, string datebegin = null);
        /// <summary>
        /// 获取三分球商品分类列表
        /// </summary>
        /// <param name="sign">apikey</param>
        /// <param name="cat_ids">分类ID集合用","分割，如:1,2,3</param>
        /// <returns>返回查询到的商品分类列表</returns>
        operateResult<responseSanfenqiuCatalogList> GetCatalogList(string sign, string cat_ids);

        operateResult<responseSanfenqiuCatalog> GetCatalog(string sign, int cat_id);

        operateResult<responseSanenqiuBrandList> GetBrandList(string sign, string brand_ids);

        operateResult<responseSanfenqiuBrand> GetBrand(string sign, int brand_id);
      
        operateResult<responseSanfenqiuStock> GetStock(string sign, int product_id);

        operateResult<responseSanfenqiuArea> GetArea(string sign, int? area_id = null, string area_name = null);
    }
}
