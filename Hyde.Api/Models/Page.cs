using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Api.Models
{
    public class Page<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int ToTalPage { get; set; }

        public int TotalItem { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }
}
