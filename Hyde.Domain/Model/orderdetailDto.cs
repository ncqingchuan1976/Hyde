using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class orderdetailDto : IEntityKey, IRowversion
    {
        public int key
        {
            get;
            set;
        }

        public int orderid { get; set; }

        public int productid { get; set; }

        public int sizeid { get; set; }

        public int supplyid { get; set; }

        public decimal orderquantity { get; set; }

        public decimal lostquantity { get; set; }

        public decimal canclequantity { get; set; }

        public decimal realquantity { get; set; }

        public decimal unitprice { get; set; }

        public decimal saleprice { get; set; }

        public byte[] lastchanged
        {
            get;

            set;
        }

        public productDto product { get; set; }

        public sizeDto size { get; set; }

        public supplyDto supply { get; set; }
    }
}
