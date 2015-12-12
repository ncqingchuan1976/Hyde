using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class productimageDto : IEntityKey
    {

        public productimageDto()
        {
            isprimary = false;
        }
        public int key
        {
            get;

            set;
        }

        public int productid { get; set; }

        public string imgpath { get; set; }

        public bool isprimary { get; set; }
    }
}
