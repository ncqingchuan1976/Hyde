using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Sanfenqiu
{

    public class responseSanfenqiuOrder
    {
        public int pages { get; set; }
        public int total { get; set; }

        public List<sanfenqiuOrder> order_list { get; set; } = new List<sanfenqiuOrder>();
    }

    public class sanfenqiuOrder
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public int order_id { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        ///外部订单号，比如淘宝订单号
        /// </summary>
        public string other_order_sn { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }
        /// <summary>
        /// 渠道ID
        /// </summary>
        public int channels_id { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string consignee { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int order_from { get; set; }
        /// <summary>
        /// 配送方式
        /// </summary>
        public int delivery_type_id { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int pay_type_id { get; set; }
        /// <summary>
        /// 支付状态;0，未支付;1，已支付；2，部分支付
        /// </summary>
        public int pay_status { get; set; }
        /// <summary>
        /// 商品销售总价格
        /// </summary>
        public decimal selling_prices { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal order_amount { get; set; }
        /// <summary>
        /// 已付金额
        /// </summary>
        public decimal money_paid { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime order_time { get; set; }
        /// <summary>
        /// 订单状态: -1=待处理,0=不存在该状态,1=已确认,2=配货中,3=已发货,4=部分发货,5=已取消,6=退货中,7=退货完成,8=客户确认收货,9=缺货 
        /// </summary>
        public Int16 order_status { get; set; }
        /// <summary>
        /// 冻结状态：1=正常,2=待审核,3=等待转款,4=小于成本价,5=冻结,6=库房不支持的配送方式
        /// </summary>
        public Int16 colded { get; set; }
        /// <summary>
        /// 订单类型；1，正常订单；2，换货订单
        /// </summary>
        public Int16 order_type { get; set; }
        /// <summary>
        /// 支付类型名称
        /// </summary>
        public string pay_type_name { get; set; }
        /// <summary>
        /// 订单状态名称
        /// </summary>
        public string order_status_name { get; set; }
        /// <summary>
        /// 支付类型名称
        /// </summary>
        public string pay_status_name { get; set; }

    }
}
