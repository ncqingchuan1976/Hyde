using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External.Sanfenqiu;
using Newtonsoft.Json;
using System.Net.Http;
using Hyde.Result.Operation;
namespace Hyde.External.Sanfenqiu
{
    public class SanfenqiuOp : ISanfenqiu
    {
        HttpClient client;
        string urlprefix = @"http://120.26.202.123/jinlang_channels/open.php?";
        public SanfenqiuOp()
        {
            client = new HttpClient();
        }

        public OperationResult<responseSanfenqiuArea> GetArea(string sign, int? area_id = default(int?), string area_name = null)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=area&a=index");

            url.AppendFormat("&sign={0}", sign);

            if (area_id.HasValue)

                url.AppendFormat("&area_id={0}", area_id.Value);

            if (!string.IsNullOrWhiteSpace(area_name))
                url.AppendFormat("&area_name={0}", area_name);


            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuArea>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuArea>(Json);

            return new OperationResult<responseSanfenqiuArea>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanfenqiuBrand> GetBrand(string sign, int brand_id)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=brand&a=get");

            url.AppendFormat("&sign={0}&brand_id={1}", sign, brand_id);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuBrand>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuBrand>(Json);

            return new OperationResult<responseSanfenqiuBrand>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanenqiuBrandList> GetBrandList(string sign, string brand_ids)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=brand&a=index");

            url.AppendFormat("&sign={0}&brand_ids={1}", sign, brand_ids);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanenqiuBrandList>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanenqiuBrandList>(Json);


            return new OperationResult<responseSanenqiuBrandList>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanfenqiuCatalog> GetCatalog(string sign, int cat_id)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=category&a=get");

            url.AppendFormat("&sign={0}&cat_id={1}", sign, cat_id);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuCatalog>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            if (Json.Contains("\"cat_id\":null"))
            {
                return new OperationResult<responseSanfenqiuCatalog>() { err_code = ErrorEnum.sys_error, err_info = ErrorEnum.sys_error.ToString() + " no data" };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuCatalog>(Json);

            return new OperationResult<responseSanfenqiuCatalog>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanfenqiuCatalogList> GetCatalogList(string sign, string cat_ids)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=category&a=index");

            url.AppendFormat("&sign={0}&cat_ids={1}", sign, cat_ids);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuCatalogList>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuCatalogList>(Json);

            return new OperationResult<responseSanfenqiuCatalogList>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanfenqiuOrder> GetOrderList(string sign, int? page = default(int?), int? page_num = default(int?), string order_ids = null, string order_sns = null, string other_order_sn = null, string consignee = null, string mobile = null, int? fromtime = default(int?))
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=order&a=index");
            url.AppendFormat("&sign={0}", sign);

            if (page.HasValue)
                url.AppendFormat("&page={0}", page.Value);

            if (page_num.HasValue)
                url.AppendFormat("&page_num={0}", page_num.Value);

            if (!string.IsNullOrWhiteSpace(order_ids))
                url.AppendFormat("&order_ids={0}", order_ids);

            if (!string.IsNullOrWhiteSpace(order_sns))
                url.AppendFormat("&order_sns={0}", order_sns);

            if (!string.IsNullOrWhiteSpace(other_order_sn))
                url.AppendFormat("&other_order_sn={0}", other_order_sn);

            if (!string.IsNullOrWhiteSpace(consignee))
                url.AppendFormat("&consignee={0}", consignee);

            if (!string.IsNullOrWhiteSpace(mobile))
                url.AppendFormat("&mobile={0}", mobile);

            if (fromtime.HasValue)
                url.AppendFormat("&fromtime={0}", fromtime.Value);

            var Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuOrder>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuOrder>(Json);

            return new OperationResult<responseSanfenqiuOrder>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanfenqiuProduct> GetProductList(string sign, int? page = null, int? page_num = null, string product_ids = null, string goods_code = null, string name = null, int? is_pic = default(int?), string datebegin = null)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=product&a=index");

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

            if (Json.Contains("error") || Json.Contains("失败"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuProduct>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuProduct>(Json);

            return new OperationResult<responseSanfenqiuProduct>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };


        }

        public OperationResult<responseSanfenqiuStock> GetStock(string sign, int product_id)
        {
            StringBuilder url = new StringBuilder(urlprefix + "c=stock&a=index");

            url.AppendFormat("&sign={0}&product_id={1}", sign, product_id);

            string Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuStock>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuStock>(Json);

            return new OperationResult<responseSanfenqiuStock>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }

        public OperationResult<responseSanfenqiuStockChange> GetStockChange(string sign, string starttime = null, string endtime = null)
        {
            StringBuilder url = new StringBuilder(urlprefix + @"c=stock&a=update_stock");

            url.AppendFormat("&sign={0}", sign);

            if (!string.IsNullOrWhiteSpace(starttime))
                url.AppendFormat("&starttime={0}", starttime);

            if (!string.IsNullOrWhiteSpace(endtime))
                url.AppendFormat("&endtime={0}", endtime);

            var Json = client.GetAsync(url.ToString()).Result.Content.ReadAsStringAsync().Result;

            if (Json.Contains("error") && Json.Contains("error_info"))
            {
                var result = JsonConvert.DeserializeObject<operateState>(Json);

                return new OperationResult<responseSanfenqiuStockChange>() { err_code = ErrorEnum.sys_error, err_info = result.error_info };
            }

            var response = JsonConvert.DeserializeObject<responseSanfenqiuStockChange>(Json);

            return new OperationResult<responseSanfenqiuStockChange>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = response };
        }
    }
}
