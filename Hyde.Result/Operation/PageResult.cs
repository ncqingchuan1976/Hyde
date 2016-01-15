using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Result.Operation
{
    public class PageResult<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPage { get; set; }

        public int TotalItem { get; set; }

        public IEnumerable<T> PageList { get; set; }
    }
}
