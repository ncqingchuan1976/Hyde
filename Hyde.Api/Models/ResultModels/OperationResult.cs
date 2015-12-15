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
        data_alreadey_exist = 10001,
        key_not_found = 10002,
        code_already_exist = 10003,
        not_in_range = 10004,
        supply_priorlevel_already_exist = 10005,
        model_not_invalid = 20000,
        model_null_parameter = 20001,
        system_err = -1
    }
}
