using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class orderpayDto : IEntityKey, IRowversion
    {
        public int key
        {
            get;
            set;
        }

        public byte[] lastchanged
        {
            get;
            set;
        }

        public int paymentid { get; set; }

        public int orderid { get; set; }

        public paymentDto payment { get; set; }

        public decimal amount { get; set; }

        public string othercode { get; set; }

        public DateTime? paydate { get; set; }
    }
}
