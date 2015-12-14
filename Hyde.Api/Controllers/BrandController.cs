using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Hyde.Api.Filters;
using Hyde.Api.Models.RequestCommands;
using Hyde.Api.Models;
using Hyde.Api.Models.RequestModels;
using Hyde.Api.Services;
using AutoMapper;
using Hyde.Domain.Model;
namespace Hyde.Api.Controllers
{
    [InvalidModelStateFilter]
    public class BrandController : ApiController
    {
        private readonly IBrandService _BrandService;

        public BrandController(IBrandService Service)
        {
            _BrandService = Service;
        }
        [HttpGet]
        public PageResult<Brand> GetBrandList(PageCommand Page = null, bool? ShutOut = null)
        {
            var page = Page ?? new PageCommand();

            var result = _BrandService.Find(page.PageIndex, page.PageSize, ShutOut);

            return result.ToPageResult<brandDto, Brand>(result.Select(t => Mapper.Map<Brand>(t)));
        }

        [HttpGet]
        public Brand GetBrand(int Key)
        {
            var Dto = _BrandService.FindSingle(Key);
            return Mapper.Map<Brand>(Dto);
        }

        [HttpPost]

        public HttpResponseMessage EditBrand([FromBody]Brand Item)
        {
            var Dto = Mapper.Map<brandDto>(Item);

            if (!_BrandService.Edit(Dto).IsSuccess)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Dto.key);
        }

        [HttpPost]

        public HttpResponseMessage AddBrand([FromBody] Brand Item)
        {
            var Dto = Mapper.Map<brandDto>(Item);

            if (!_BrandService.Add(Dto).IsSuccess)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Dto.key);
        }

    }
}
