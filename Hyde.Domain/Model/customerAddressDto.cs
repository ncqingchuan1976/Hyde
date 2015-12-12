using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class customerAddressDto : IEntityKey
    {

        public customerAddressDto()
        {
            isdefault = false;
            shutout = false;
            reciptaddress = new address();
        }
        public int key
        {
            get;
            set;
        }

        public int customerid { get; set; }
        public address reciptaddress { get; set; }

        public bool isdefault { get; set; }

        public int areaid { get; set; }

        public bool shutout { get; set; }
        public areaDto area { get; set; }
    }
}
