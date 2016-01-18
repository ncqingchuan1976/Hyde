using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Highwave.Models
{
    public class product
    {
        public product()
        {
            skus = new List<sku>();
        }
        public string Goods_no { get; set; }

        public string Brand { get; set; }

        public string Category { get; set; }

        public string Year { get; set; }

        public string Season { get; set; }

        public string Sex { get; set; }

        public string Goods_Name { get; set; }

        public string Size_class { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime Input_Date { get; set; }

        public virtual List<sku> skus { get; set; }
    }

    public class sku
    {
        public string Goods_no { get; set; }

        public string Size { get; set; }

        public string BarCode { get; set; }
    }
}
