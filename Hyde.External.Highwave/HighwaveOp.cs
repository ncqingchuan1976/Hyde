using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
namespace Hyde.External.Highwave
{
    public class HighwaveOp : IHighwave, IDisposable
    {
        private HttpClient client = new HttpClient();

        public void Dispose()
        {
            if (client != null)
                client.Dispose();

        }

        public async Task<operateResult<accessToken>> GetAccessTocken(string UserName, string PassWord)
        {
            StringBuilder url = new StringBuilder("http://192.168.10.221/highwave/token");

            string grant_type = "password";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("username", UserName);
            parameters.Add("password", PassWord);
            parameters.Add("grant_type", grant_type);

            FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);

            var result = await client.PostAsync(url.ToString(), content);

            if (result.StatusCode == HttpStatusCode.BadRequest)
            {
                var Jsonerr = result.Content.ReadAsStringAsync().Result;

                var err = JsonConvert.DeserializeObject<error_state>(Jsonerr);

                return new operateResult<accessToken>() { error = -1, error_info = err.error + " " + err.error_description };
            }

            var Json = result.Content.ReadAsStringAsync().Result;

            var token = JsonConvert.DeserializeObject<accessToken>(Json);

            return new operateResult<accessToken>() { error = 0, error_info = "success", data = token };
        }
    }
}
