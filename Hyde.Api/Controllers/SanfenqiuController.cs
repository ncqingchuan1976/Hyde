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
using System.Configuration;
using Hyde.Api.Models.RequestCommands;
using Hyde.Api.Filters;
namespace Hyde.Api.Controllers
{
    [InvalidModelStateFilter]
    public class SanfenqiuController : ApiController
    {
        string apikey = ConfigurationManager.AppSettings["apikey"];

        readonly ISanfenqiu service;
        public SanfenqiuController(ISanfenqiu Service)
        {
            service = Service;
        }
        [HttpGet]
        public HttpResponseMessage GetArea(int? area_id = null, string area_name = null)
        {
            var result = service.GetArea(apikey, area_id, area_name);

            if (result.error != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new OperationResult(errstate.system_err, result.error_info));
            }
            return Request.CreateResponse(HttpStatusCode.OK, new OperationResult<responseSanfenqiuArea>(errstate.success, errstate.success.ToString()) { Entity = result.data });
        }
        [HttpGet]
        public HttpResponseMessage GetProductList(PageCommand Page = null, string Product_ids = null, string Goods_Code = null, string Name = null, int? isPic = null, DateTime? StartDate = null)
        {
            PageCommand page = Page ?? new PageCommand();

            var start = StartDate?.ToString("yyyy-MM-dd");

            var result = service.GetProductList(apikey, page.PageIndex, page.PageSize, Product_ids, Goods_Code, Name, isPic, start);

            if (result.error != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new OperationResult(errstate.system_err, result.error_info));
            }

            return Request.CreateResponse(HttpStatusCode.OK, new OperationResult<PageResult<sanfenqiuProduct>>(errstate.success, errstate.success.ToString())
            {
                Entity = new PageResult<sanfenqiuProduct>()
                {
                    PageIndex = page.PageIndex,
                    PageSize = page.PageSize,
                    TotalItem = result.data.total,
                    ToTalPage = (int)Math.Ceiling((((double)result.data.total / page.PageSize))),
                    Entities = result.data.product_list
                }
            });
        }
        [HttpGet]
        public HttpResponseMessage GetCatalogList(string Catalog_ids = null)
        {
            var result = service.GetCatalogList(apikey, Catalog_ids);

            if (result.error != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new OperationResult(errstate.system_err, result.error_info));
            }
            return Request.CreateResponse(HttpStatusCode.OK, new OperationResult<responseSanfenqiuCatalogList>(errstate.success, errstate.success.ToString()) { Entity = result.data });
        }
        [HttpGet]
        public HttpResponseMessage GetCatalog(int Key)
        {
            var result = service.GetCatalog(apikey, Key);

            if (result.error != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new OperationResult(errstate.system_err, result.error_info));
            }
            return Request.CreateResponse(HttpStatusCode.OK, new OperationResult<responseSanfenqiuCatalog>(errstate.success, errstate.success.ToString()) { Entity = result.data });
        }
    }
}
