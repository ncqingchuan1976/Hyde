using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Model.RequestModels;
using Hyde.Api.Model.RequestCommands;
using Hyde.Api.Models;
using PagedList;
namespace Hyde.Api.Services
{
    public interface IBrandService
    {
        IPagedList<BrandAdd> Find(int PageIndex, int PageSize, bool? ShutOut = null);

        BrandAdd FindSingle(int Key);

        BrandAdd FindSingle(string Code);


    }
}
