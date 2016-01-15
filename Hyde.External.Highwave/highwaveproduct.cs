using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Highwave
{

    public class PageResponse<T>
    {
        public int PageIndex { get; set; }

        public int TotalItem { get; set; }

        public int TotalPage { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<T> Data { get; set; }
    }  

    public class highwaveproduct
    {
        public highwaveproduct()
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
