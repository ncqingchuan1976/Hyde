using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hyde.Domain.Model;
using Hyde.Api.Services;
using Hyde.Api.Models.ResultModels;
using Hyde.Api.Models.RequestModels;
using Hyde.Api.Filters;
using Hyde.Api.Models.RequestCommands;
using AutoMapper;
namespace Hyde.Api.Controllers
{
    [InvalidModelStateFilter]
    public class SupplyController : ApiController
    {
        private readonly ISupplyService service;

        public SupplyController(ISupplyService Service)
        {
            service = Service;
        }

        [HttpGet]
        public PageResult<Supply> GetSupplyList(PageCommand Page = null, string Name = null, string Code = null, Boolean? ShuOut = null)
        {
            var page = Page ?? new PageCommand();

            var result = service.Find(page.PageIndex, page.PageSize, Name, Code, ShuOut);

            return result.ToPageResult<supplyDto, Supply>(result.Select(t => Mapper.Map<Supply>(t)));
        }
        [HttpPost]
        [EmptyParameterFilter("Item")]
        public HttpResponseMessage AddSupply(Supply Item)
        {
            var Dto = Mapper.Map<supplyDto>(Item);

            var result = service.Add(Dto);

            switch (result.Code)
            {
                case errstate.data_allreadey_exists:
                    return Request.CreateResponse(HttpStatusCode.BadRequest, result);

            }

            return Request.CreateResponse(HttpStatusCode.OK, Dto.key);

        }

        [HttpPost]
        [EmptyParameterFilter("Item")]
        public HttpResponseMessage EditSupply(Supply Item)
        {
            var Dto = Mapper.Map<supplyDto>(Item);

            var result = service.Edit(Dto);

            if (result.Code == errstate.data_allreadey_exists)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage DeleteSupply(int Key)
        {
            var Dto = service.Create();
            var result = service.Delete(Dto);

            if (result.Code == errstate.ket_not_found)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [EmptyParameterFilter("Keys")]
        public HttpResponseMessage DeleteSupply([FromBody]int[] Keys)
        {
            var result = service.Delete(Keys);

            if (result.Code == errstate.not_in_range)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public Supply GetSupply(int Key)
        {
            var Dto = service.FindSingle(Key);

            return Mapper.Map<Supply>(Dto);
        }
    }
}
