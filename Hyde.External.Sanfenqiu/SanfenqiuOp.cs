using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External.Sanfenqiu;
using Newtonsoft.Json;
using System.Net.Http;

namespace Hyde.External.Sanfenqiu
{
    public class SanfenqiuOp : ISanfenqiu
    {

        HttpClient client;

        public SanfenqiuOp()
        {
            client = new HttpClient() { BaseAddress = new Uri("http://120.26.202.123") };

        }

        public operateResult<responseSanfenqiuArea> GetArea(string sign, int? area_id = default(int?), string area_name = null)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=area&a=index");

            url.AppendFormat("&sign={0}", sign);

            if (area_id.HasValue)

                url.AppendFormat("&area_id={0}", area_id.Value);

            if (!string.IsNullOrWhiteSpace(area_name))
                url.AppendFormat("&area_name={0}", area_name);


            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanfenqiuArea>() { error = result.error, error_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuArea>(Json);

            return new operateResult<responseSanfenqiuArea>() { error = 0, error_info = "success", data = response };
        }



        public operateResult<responseSanfenqiuBrand> GetBrand(string sign, int brand_id)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=brand&a=get");

            url.AppendFormat("&sign={0}&brand_id={1}", sign, brand_id);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanfenqiuBrand>() { error = result.error, error_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuBrand>(Json);

            return new operateResult<responseSanfenqiuBrand>() { error = 0, error_info = "success", data = response };
        }

        public operateResult<responseSanenqiuBrandList> GetBrandList(string sign, string brand_ids)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=brand&a=index");

            url.AppendFormat("&sign={0}&brand_ids={1}", sign, brand_ids);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanenqiuBrandList>() { error = result.error, error_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanenqiuBrandList>(Json);


            return new operateResult<responseSanenqiuBrandList>() { error = 0, error_info = "success", data = response };
        }

        public operateResult<responseSanfenqiuCatalog> GetCatalog(string sign, int cat_id)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=category&a=get");

            url.AppendFormat("&sign={0}&cat_id={1}", sign, cat_id);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanfenqiuCatalog>() { error = result.error, error_info = result.error_info };
            }

            if (Json.Contains("\"cat_id\":null"))
            {
                return new operateResult<responseSanfenqiuCatalog>() { error = -1, error_info = "no data" };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuCatalog>(Json);

            return new operateResult<responseSanfenqiuCatalog>() { error = 0, error_info = "success", data = response };
        }

        public operateResult<responseSanfenqiuCatalogList> GetCatalogList(string sign, string cat_ids)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=category&a=index");

            url.AppendFormat("&sign={0}&cat_ids={1}", sign, cat_ids);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanfenqiuCatalogList>() { error = result.error, error_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuCatalogList>(Json);

            return new operateResult<responseSanfenqiuCatalogList>() { error = 0, error_info = "success", data = response };
        }

        public operateResult<responseSanfenqiuProduct> GetProductList(string sign, int? page = null, int? page_num = null, string product_ids = null, string goods_code = null, string name = null, int? is_pic = default(int?), string datebegin = null)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=product&a=index");

            url.AppendFormat("&sign={0}", sign);

            if (page.HasValue)
                url.AppendFormat("&page={0}", page);

            if (page_num.HasValue)
                url.AppendFormat("&page_num={0}", page_num);

            if (!string.IsNullOrWhiteSpace(product_ids))
                url.AppendFormat("&product_ids={0}", product_ids);

            if (!string.IsNullOrWhiteSpace(goods_code))
                url.AppendFormat("&goods_code={0}", goods_code);

            if (!string.IsNullOrWhiteSpace(name))
                url.AppendFormat("&name={0}", name);

            if (is_pic.HasValue)
                url.AppendFormat("&is_pic={0}", is_pic.Value);

            if (!string.IsNullOrWhiteSpace(datebegin))
                url.AppendFormat("&datebegin={0}", datebegin);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error")|| Json.Contains("失败"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanfenqiuProduct>() { error = result.error, error_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuProduct>(Json);

            return new operateResult<responseSanfenqiuProduct>() { error = 0, error_info = "success", data = response };


        }

        public operateResult<responseSanfenqiuStock> GetStock(string sign, int product_id)
        {
            StringBuilder url = new StringBuilder("jinlang_channels/open.php?c=stock&a=index");

            url.AppendFormat("&sign={0}&product_id={1}", sign, product_id);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new operateResult<responseSanfenqiuStock>() { error = result.error, error_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuStock>(Json);

            return new operateResult<responseSanfenqiuStock>() { error = 0, error_info = "success", data = response };
        }
    }
}
