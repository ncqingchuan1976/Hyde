using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Sanfenqiu
{

    public class responseSanfenqiuCatalogList
    {
        public List<sanfenqiuCatalog> category_list { get; set; }
    }

    public class responseSanfenqiuCatalog
    {
        public List<sanfenqiuCatalog> category { get; set; }
    }

    public class sanfenqiuCatalog
    {
        public int cat_id { get; set; }

        public string cat_name { get; set; }

        public int parent_id { get; set; }

        public int attr_template { get; set; }

        public string keyword { get; set; }

        public string descript { get; set; }



    }
}
