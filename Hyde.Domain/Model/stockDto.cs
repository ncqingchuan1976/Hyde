using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
using Hyde.Common;
namespace Hyde.Domain.Model
{
    public class stockDto : IEntityKey
    {
        public int key
        {
            get;

            set;
        }

        public int supplyid { get; set; }

        public int warehouseid { get; set; }

        public int productid { get; set; }

        public int sizeid { get; set; }

        public decimal quantity { get; set; }

        public DateTime createdatetime { get; set; }

        public STOCK_DIRECTOR stockdirector { get; set; }

        public productDto product { get; set; }

        public sizeDto size { get; set; }

        public warehouseDto warehouse { get; set; }

        public supplyDto supply { get; set; }
    }
}
