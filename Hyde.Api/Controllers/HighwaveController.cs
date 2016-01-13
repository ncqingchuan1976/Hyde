using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Hyde.External.Highwave;
using Hyde.Api.Models.ResultModels;
using System.Configuration;
using Hyde.Api.Models.RequestCommands;
using Hyde.Api.Filters;
using System.Web;
namespace Hyde.Api.Controllers
{
    public class HighwaveController : ApiController
    {
        IHighwave service;
        public HighwaveController(IHighwave Service)
        {
            service = Service;
        }
        [HttpPost]
        public async Task<HttpResponseMessage> GetToken(string userName, string passWord)
        {
            var result = await service.GetAccessTocken(userName, passWord);

            if(result.error!=0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
