using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hyde.Domain.Model;
using Hyde.Repository;
namespace Hyde.Api.Host.Controllers
{
    public class SupplyController : ApiController
    {


        private readonly IRepository<supplyDto> _SupplyRepo;

        public SupplyController(IRepository<supplyDto> SupplyRepo)
        {
            _SupplyRepo = SupplyRepo;
        }

        [HttpGet]

        public List<supplyDto> GetSupplyList()
        {
            return _SupplyRepo.Find().ToList();
        }
    }
}
