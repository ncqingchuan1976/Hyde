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
        /// <summary>
        ///SKUID
        /// </summary>
        public int sku_id { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int product_id { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int supplier_id { get; set; }
        /// <summary>
        /// 库房ID
        /// </summary>
        public int warehouse_id { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string warehouse_name { get; set; }
        /// <summary>
        /// 销售方式ID
        /// </summary>
        public int sales_way_id { get; set; }
        /// <summary>
        /// 销售方式名称
        /// </summary>
        public string sales_way_name { get; set; }
        /// <summary>
        /// 厂家尺码
        /// </summary>
        public string true_size { get; set; }
        /// <summary>
        /// 显示尺码
        /// </summary>
        public string show_size { get; set; }
        /// <summary>
        /// 厂商码,条形码
        /// </summary>
        public string bar_code { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public int discount { get; set; }
        /// <summary>
        /// 代理价
        /// </summary>
        public float agent_price { get; set; }
        /// <summary>
        /// 可用库存数
        /// </summary>
        public int usable_qty { get; set; }
    }

    public class responseSanfenqiuStockChange
    {
        public int error { get; set; }

        public List<int> data { get; set; } = new List<int>();
    }
}
