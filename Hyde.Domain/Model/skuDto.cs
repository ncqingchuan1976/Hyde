using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class skuDto : IEntityKey
    {
        public int key
        {
            get;

            set;
        }
        public int productid { get; set; }

        public int sizeid { get; set; }

        public string barcode { get; set; }

        public productDto product { get; set; }
        public sizeDto size { get; set; }
    }
}
