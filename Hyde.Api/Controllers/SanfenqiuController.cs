using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Hyde.External.Sanfenqiu;
using Hyde.Api.Models.ResultModels;
namespace Hyde.Api.Controllers
{
    public class SanfenqiuController : ApiController
    {
        readonly string akikey = "a515AgFUVQBTCAAFAAJVAwdQXFYBB15XXgkGVQBXBwUVDRtdZgYnCTY";

        readonly ISanfenqiu service;
        public SanfenqiuController(ISanfenqiu Service)
        {
            service = Service;
        }

        public HttpResponseMessage GetArea(int? area_id = null, string area_name = null)
        {
            var result = service.GetArea(akikey, area_id, area_name);

            if (result.error != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result.error_info);
            }
            return Request.CreateResponse(HttpStatusCode.OK, new OperationResult<responseSanfenqiuArea>(errstate.success, errstate.success.ToString()) { Entity = result.data });
        }
    }
}
