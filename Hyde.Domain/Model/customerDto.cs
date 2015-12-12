using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class customerDto : IEntityKey
    {
        public int key
        {
            get;

            set;
        }

        public string openid { get; set; }

        public DateTime createdate { get; set; }

        public string name { get; set; }

        public bool shutout { get; set; }

        public DateTime? modidate { get; set; }

        public int modicount { get; set; }

        public string groupname { get; set; }

        public virtual List<customerAddressDto> addresses { get; set; }

        public virtual List<orderDto> orders { get; set; }
    }
}
