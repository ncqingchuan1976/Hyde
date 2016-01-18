using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;
using Hyde.Result.Operation;
using Hyde.External.Highwave.Models;
namespace Hyde.External.Highwave
{
    public class HighwaveOp : IHighwave, IDisposable
    {
        private HttpClient client = new HttpClient();
        private const string grant_type = "password";
        private readonly string url = ConfigurationManager.AppSettings["Url"];
        private const string contentType = "Application/Json";
        private const string authorizationScheam = "Bearer";
        public void Dispose()
        {
            if (client != null)
                client.Dispose();
        }

        public async Task<OperationResult<accessToken>> GetAccessTocken(string UserName, string PassWord)
        {
            StringBuilder requestUrl = new StringBuilder(url + "/token");

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("username", UserName);
            parameters.Add("password", PassWord);
            parameters.Add("grant_type", grant_type);

            FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);

            var result = await client.PostAsync(requestUrl.ToString(), content);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var Jsonerr = result.Content.ReadAsStringAsync().Result;

                var err = JsonConvert.DeserializeObject<error_state>(Jsonerr);

                return new OperationResult<accessToken>() { err_code = ErrorEnum.sys_error, err_info = err.error + " " + err.error_description };
            }

            var Json = result.Content.ReadAsStringAsync().Result;

            var token = JsonConvert.DeserializeObject<accessToken>(Json);

            return new OperationResult<accessToken>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = token };
        }

        public async Task<OperationResult<PageResult<product>>> GetHighwaveProduct(string accessToken, string[] brands, DateTime start, DateTime? end = null, int pageIndex = 1, int pageSize = 20)
        {
            string requestUrl = string.Format(url + @"/highwave/GetProduct?pageIndex={0}&pageSize={1}", pageIndex, pageSize);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, accessToken);

            var postString = new StringContent(JsonConvert.SerializeObject(new { brands = brands, start = start, end = end }));

            postString.Headers.ContentType.MediaType = contentType;

            var result = await client.PostAsync(requestUrl, postString);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var errorStr = await result.Content.ReadAsStringAsync();

                var error = JsonConvert.DeserializeObject<OperationResult>(errorStr);

                return new OperationResult<PageResult<Models.product>>() { err_code = error.err_code, err_info = error.err_info };
            }

            var Json = result.Content.ReadAsStringAsync().Result;

            PageResult<product> product = JsonConvert.DeserializeObject<PageResult<product>>(Json);

            return new OperationResult<PageResult<product>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = product };
        }

        public async Task<OperationResult<List<sku>>> GetHighwaveBarcode(string accessToken, string[] productCodes)
        {
            string requestUrl = url + @"/highwave/GetBarcode";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, accessToken);

            var postString = new StringContent(JsonConvert.SerializeObject(productCodes));

            postString.Headers.ContentType.MediaType = contentType;

            var result = await client.PostAsync(requestUrl, postString);

            var Json = result.Content.ReadAsStringAsync().Result;

            List<sku> product = JsonConvert.DeserializeObject<List<sku>>(Json);

            return new OperationResult<List<sku>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = product };

        }

        public async Task<OperationResult<List<sex>>> GetHighwaveSex(string accessToken)
        {
            string requestUrl = url + @"/highwave/GetSex";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, accessToken);

            var result = await client.GetAsync(requestUrl);

            var Json = result.Content.ReadAsStringAsync().Result;

            List<sex> sex = JsonConvert.DeserializeObject<List<sex>>(Json);

            return new OperationResult<List<sex>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = sex };
        }

        public async Task<OperationResult<List<sizeclass>>> GetHighwaveSizeClass(string accessToken)
        {
            string requestUrl = url + @"/highwave/GetSizeClass";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, accessToken);

            var result = await client.GetAsync(requestUrl);

            var Json = result.Content.ReadAsStringAsync().Result;

            List<sizeclass> sizeclass = JsonConvert.DeserializeObject<List<sizeclass>>(Json);

            return new OperationResult<List<sizeclass>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = sizeclass };
        }

        public async Task<OperationResult<List<category>>> GetHighwaveCategory(string accessToken)
        {
            string requestUrl = url + @"/highwave/GetCategory";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, accessToken);

            var result = await client.GetAsync(requestUrl);

            var Json = result.Content.ReadAsStringAsync().Result;

            List<category> category = JsonConvert.DeserializeObject<List<category>>(Json);

            return new OperationResult<List<category>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = category };
        }

        public async Task<OperationResult<List<brand>>> GetHighwaveBrand(string accessToken)
        {
            string requestUrl = url + @"/highwave/GetBrand";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, accessToken);

            var result = await client.GetAsync(requestUrl);

            var Json = result.Content.ReadAsStringAsync().Result;

            List<brand> brand = JsonConvert.DeserializeObject<List<brand>>(Json);

            return new OperationResult<List<brand>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = brand };
        }
    }
}
