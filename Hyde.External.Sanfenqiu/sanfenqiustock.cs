using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Sanfenqiu
{


    public class responseSanfenqiuStock
    {
        public List<sanfenqiuStock> stock_info { get; set; } = new List<sanfenqiuStock>();
    }

    public class sanfenqiuStock
    {
        public int sku_id { get; set; }

        public int product_id { get; set; }

        public int supplier_id { get; set; }

        public int warehouse_id { get; set; }

        public string warehouse_name { get; set; }

        public int sales_way_id { get; set; }

        public string sales_way_name { get; set; }

        public string true_size { get; set; }

        public string show_size { get; set; }

        public string bar_code { get; set; }

        public int discount { get; set; }

        public float agent_price { get; set; }

        public int usable_qty { get; set; }
    }
}
