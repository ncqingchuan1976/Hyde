using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External;
using Hyde.External.Sanfenqiu;
namespace Hyde.External.Sanfenqiu
{
    public interface ISanfenqiu : IExternal
    {
        operateResult<responseSanfenqiuProduct> GetProductList(string sign, int? page = null, int? page_num = null, string product_ids = null, string goods_code = null, string name = null, int? is_pic = null, string datebegin = null);
        
        operateResult<responseSanfenqiuCatalogList> GetCatalogList(string sign, string cat_ids);

        operateResult<responseSanfenqiuCatalog> GetCatalog(string sign, int cat_id);

        operateResult<responseSanenqiuBrandList> GetBrandList(string sign, string brand_ids);

        operateResult<responseSanfenqiuBrand> GetBrand(string sign, int brand_id);
      
        operateResult<responseSanfenqiuStock> GetStock(string sign, int product_id);

        operateResult<responseSanfenqiuArea> GetArea(string sign, int? area_id = null, string area_name = null);
    }
}
