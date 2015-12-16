using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class orderDto : IEntityKey, IRowversion
    {

        public orderDto()
        {
            address = new address();
        }

        public int key { get; set; }

        public int customerid { get; set; }

        public ORDER_STATE orderstatus { get; set; }

        public string code { get; set; }

        public string othercode { get; set; }

        public DateTime createdate { get; set; }

        public DateTime? cancledate { get; set; }

        public DateTime? paydate { get; set; }

        public DateTime? deliverydate { get; set; }

        public string remark { get; set; }

        public address address { get; set; }

        public byte[] lastchanged { get; set; }

        public customerDto customer { get; set; }

        public virtual List<orderdetailDto> orderdetails { get; set; } = new List<orderdetailDto>();

        public virtual List<orderpayDto> orderpays { get; set; } = new List<orderpayDto>();

    }
}
