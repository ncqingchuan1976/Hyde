using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Api.Models
{
    public abstract class OperationResult
    {
        public bool IsSuccess { get; private set; }
        public OperationResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }

    public class OperateReult<T> : OperationResult
    {
        public OperateReult(bool isSuccess)
            : base(isSuccess)
        { }
        T Entity { get; set; }
    }
}
