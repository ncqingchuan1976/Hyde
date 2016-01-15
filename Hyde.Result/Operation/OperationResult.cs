using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Result.Operation
{
    public class OperationResult
    {
        public ErrorEnum err_code { get; set; }

        public string err_info { get; set; }
    }

    public class OperationResult<T> : OperationResult
    {
        public T entity { get; set; }
    }
}
