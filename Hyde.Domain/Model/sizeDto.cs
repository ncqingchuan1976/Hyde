using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class sizeDto : IEntityKey
    {
        public int key
        {
            get;

            set;
        }

        public string code { get; set; }

        public string sizegroup { get; set; }

        public string displaycode { get; set; }
    }
}
