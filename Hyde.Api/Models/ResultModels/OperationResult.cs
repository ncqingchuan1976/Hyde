using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Api.Models.ResultModels
{
    public class OperationResult
    {
        public errstate Code { get; }
        public string Message { get; }
        public OperationResult(errstate code, string message)
        {
            Code = code;
            Message = message;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public OperationResult(errstate code, string message)
            : base(code, message)
        {

        }
        public T Entity { get; set; }

    }

    public enum errstate
    {
        success = 0,
        data_not_found = 10000,
        data_allreadey_exists = 10001,
        ket_not_found = 10002,
        key_allreadey_exists = 10003,
        not_in_range = 10004,
        model_not_invalid = 20000,
        model_null_parameter = 20001,
        system_err = -1
    }
}
