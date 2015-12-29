using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Sanfenqiu

{  
    public class responseSanfenqiuProduct
    {
        public int total { get; set; }

        public int pages { get; set; }

        public List<sanfenqiuProduct> product_list { get; set; } = new List<sanfenqiuProduct>();
    }

    public class sanfenqiuProduct
    {

        public int pro_id { get; set; }
        /// <summary>
        /// 商品货号
        /// </summary>
        public string goods_code { get; set; }
        /// <summary>
        /// 款号
        /// </summary>
        public string style_code { get; set; }
        /// <summary>
        /// 色号
        /// </summary>

        public string color_code { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public int cat_id { get; set; }
        /// <summary>
        /// 顶级分类ID
        /// </summary>
        public int parent_catid { get; set; }
        /// <summary>
        /// 品牌id
        /// </summary>
        public int brand_id { get; set; }
        /// <summary>
        /// 尺码对照表ID
        /// </summary>
        public int size_contrast_id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 商品英文名称
        /// </summary>
        public string ename { get; set; }
        /// <summary>
        /// 是否有主图 1 有 0 无
        /// </summary>
        public Int16 is_pic { get; set; }
        /// <summary>
        /// 市场价
        /// </summary>
        public decimal market_price { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal sell_price { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string simple_intro { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public string intro { get; set; }
        /// <summary>
        /// 关键词
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 运营优化标题
        /// </summary>
        public string seo_title { get; set; }
        /// <summary>
        /// 上市日期
        /// </summary>
        public DateTime? listing_date { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? up_time { get; set; }
        /// <summary>
        /// 上架时间
        /// </summary>
        public DateTime? up_date { get; set; }
        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime? down_date { get; set; }
        /// <summary>
        /// 是否新品；1，新品；0，不是新品（自动更新， 上市日期小于3个月为新品）
        /// </summary>
        public Int16 is_new { get; set; }
        /// <summary>
        /// 是否特价：1，特价；0，否
        /// </summary>
        public Int16 is_specials { get; set; }
        /// <summary>
        /// 是否断码；1,是；0，否（自动更新，服装类商品（包含：户外分类服装）,库存只有1个尺码，即可判断为“断码商品”，鞋商品（包含：户外分类鞋），库存只有2个尺码，即可判断为“断码商品”）
        /// </summary>
        public Int16 is_broken_code { get; set; }
        /// <summary>
        /// 状态：0-下架1-上架2-冻结4-赠品5-临时
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 商品主图
        /// </summary>
        public string main_pic { get; set; }
        /// <summary>
        /// 商品属性
        /// </summary>
        //public List<attrib_pic> attr_info { get; set; } = new List<attrib_pic>();

    }
    /// <summary>
    /// 商品属性
    /// </summary>
    public class attrib_pic
    {
        /// <summary>
        /// 属性解释ID。 如：性别，颜色，场合，尺码，季节，色系。每一个attr_field_id代表对应的属性。
        /// </summary>
        public string attr_field_id { get; set; }
        /// <summary>
        /// 属性值。 如：性别：男
        /// </summary>
        public string attr_val { get; set; }
        /// <summary>
        /// 属性解释名称。 如 性别，颜色，场合，尺码，季节，色系等
        /// </summary>
        public string attr_field_name { get; set; }
    }


}
