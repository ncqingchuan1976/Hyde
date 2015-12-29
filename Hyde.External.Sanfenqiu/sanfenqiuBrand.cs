using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Sanfenqiu
{

    public class responseSanenqiuBrandList
    {
        public List<sanfenqiuBrand> brand_list { get; set; } = new List<sanfenqiuBrand>();
    }

    public class responseSanfenqiuBrand
    {
        public sanfenqiuBrand brand { get; set; }
    }

    public class sanfenqiuBrand
    {
        public int brand_id { get; set; }
        public string brand_name { get; set; }

        public string brand_ename { get; set; }

        public string brand_logo { get; set; }

        public string brand_desc { get; set; }
    }
}
