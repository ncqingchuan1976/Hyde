using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External;
namespace Hyde.External.Highwave
{
    public interface IHighwave : IExternal
    {
        Task<operateResult<accessToken>> GetAccessTocken(string UserName, string PassWord);

        Task<operateResult<PageResponse<highwaveproduct>>> GetHighwaveProduct(string apikey, string[] brands, DateTime start, DateTime? end = null, int pageIndex = 1, int pageSize = 20);

        Task<operateResult<List<sku>>> GetHighwaveBarcode(string apikey,string[] productCodes);
    }
}
