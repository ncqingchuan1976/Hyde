using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Domain.Model
{
    public class supplyDto : IEntityKey
    {
        public int key
        {
            get;

            set;
        }

        public string code { get; set; }

        public string name { get; set; }

        public bool shutout { get; set; } = false;

        public string remark { get; set; }

        public int priorlevel { get; set; }

    }
}
