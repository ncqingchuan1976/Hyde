using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Sanfenqiu
{

    public class responseSanfenqiuArea
    {
        public int total { get; set; }

        public List<saanfenqiuArea> area_info { get; set; } = new List<saanfenqiuArea>();
    }

    public class saanfenqiuArea
    {
        public int area_id { get; set; }

        public string area_name { get; set; }

        public int area_parent_id { get; set; }

        public string area_zip { get; set; }
    }
}
