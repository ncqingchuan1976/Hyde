using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    /// <summary>
    /// 品牌
    /// </summary>
    public class brandDto : IEntityKey
    {

        public brandDto()
        {
            shutout = false;
        }
        
        public int key
        {
            get;

            set;
        }

        public string name { get; set; }

        public string enname { get; set; }

        public bool shutout { get; set; }

        public string imgpath { get; set; }
    }
}
