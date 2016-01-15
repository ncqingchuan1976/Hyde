using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External;
using Hyde.Result.Operation;
namespace Hyde.External.Highwave
{
    public interface IHighwave : IExternal
    {
        Task<OperationResult<accessToken>> GetAccessTocken(string UserName, string PassWord);

        Task<OperationResult<PageResponse<highwaveproduct>>> GetHighwaveProduct(string apikey, string[] brands, DateTime start, DateTime? end = null, int pageIndex = 1, int pageSize = 20);

        Task<OperationResult<List<sku>>> GetHighwaveBarcode(string apikey,string[] productCodes);
    }
}
