using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Result.Operation;
using Hyde.Domain.Model;
namespace Hyde.Service
{
    public interface ISizeService : IService
    {
        Task<OperationResult<List<sizeDto>>> GetSizeListAsync();

        Task<OperationResult> AddSizeAsync(IEnumerable<sizeDto> items);
    }
}
