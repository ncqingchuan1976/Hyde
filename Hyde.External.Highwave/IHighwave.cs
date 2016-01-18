using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External;
using Hyde.Result.Operation;
using Hyde.External.Highwave.Models;
namespace Hyde.External.Highwave
{
    public interface IHighwave : IExternal
    {
        Task<OperationResult<accessToken>> GetAccessTocken(string UserName, string PassWord);

        Task<OperationResult<PageResult<product>>> GetHighwaveProduct(string accessToken, string[] brands, DateTime start, DateTime? end = null, int pageIndex = 1, int pageSize = 20);

        Task<OperationResult<List<sku>>> GetHighwaveBarcode(string accessToken, string[] productCodes);

        Task<OperationResult<List<sex>>> GetHighwaveSex(string accessToken);

        Task<OperationResult<List<sizeclass>>> GetHighwaveSizeClass(string accessToken);

        Task<OperationResult<List<category>>> GetHighwaveCategory(string accessToken);

        Task<OperationResult<List<brand>>> GetHighwaveBrand(string accessToken);
    } 
}
