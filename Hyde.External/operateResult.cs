using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External
{
    public class operateResult<T>
    {
        public int error { get; set; }

        public string error_info { get; set; }

        public T data { get; set; }
    }

}
