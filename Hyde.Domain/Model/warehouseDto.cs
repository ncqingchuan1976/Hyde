using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class warehouseDto : IEntityKey
    {

        public warehouseDto()
        {
            shutout = false;
            v_stocks = new List<v_stockDto>();
        }
        public int key
        {
            get;

            set;
        }

        public string code { get; set; }

        public string name { get; set; }

        public bool shutout { get; set; }

        public virtual List<v_stockDto> v_stocks { get; set; }
    }
}
