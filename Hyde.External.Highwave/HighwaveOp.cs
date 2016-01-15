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

        public async Task<OperationResult<PageResponse<highwaveproduct>>> GetHighwaveProduct(string apikey, string[] brands, DateTime start, DateTime? end = null, int pageIndex = 1, int pageSize = 20)
        {
            string requestUrl = string.Format(url + @"/highwave/GetProduct?pageIndex={0}&pageSize={1}", pageIndex, pageSize);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, apikey);

            var postString = new StringContent(JsonConvert.SerializeObject(new { brands = brands, start = start, end = end }));

            postString.Headers.ContentType.MediaType = contentType;

            var result = await client.PostAsync(requestUrl, postString);

            var Json = result.Content.ReadAsStringAsync().Result;

            PageResponse<highwaveproduct> product = JsonConvert.DeserializeObject<PageResponse<highwaveproduct>>(Json);

            return new OperationResult<PageResponse<highwaveproduct>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = product };
        }

        public async Task<OperationResult<List<sku>>> GetHighwaveBarcode(string apikey, string[] productCodes)
        {
            string requestUrl = url + @"/highwave/GetBarcode";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorizationScheam, apikey);

            var postString = new StringContent(JsonConvert.SerializeObject(productCodes));

            postString.Headers.ContentType.MediaType = contentType;

            var result = await client.PostAsync(requestUrl, postString);

            var Json = result.Content.ReadAsStringAsync().Result;

            List<sku> product = JsonConvert.DeserializeObject<List<sku>>(Json);

            return new OperationResult<List<sku>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = product };

        }
    }
}
