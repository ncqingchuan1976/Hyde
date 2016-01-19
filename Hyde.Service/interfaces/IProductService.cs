using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Result.Operation;
using Hyde.Domain.Model;
using Hyde.Repository;
namespace Hyde.Service
{
    public interface IProductService : IService
    {
        Task<OperationResult<List<productDto>>> GetProductListAsync(string[] productcodes);

        Task<OperationResult> AddProductAsync(IEnumerable<productDto> items);

    }
}
