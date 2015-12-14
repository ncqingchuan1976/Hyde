using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Hyde.Api.Filters;
using Hyde.Api.RequestCommands;
using Hyde.Api.Models;
using Hyde.Api.Model.RequestModels;
using Hyde.Api.Services;
using AutoMapper;
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

            return new PageResult<Brand>()
            {
                PageIndex = result.PageNumber,
                PageSize = result.PageSize,
                TotalItem = result.TotalItemCount,
                ToTalPage = result.PageCount,
                Entities = result.Select(t => Mapper.Map<Brand>(t))


            };
        }

        [HttpGet]
        public Brand GetBrand(int Key)
        {
            var Dto = _BrandService.FindSingle(Key);
            return Mapper.Map<Brand>(Dto);
        }

    }
}
