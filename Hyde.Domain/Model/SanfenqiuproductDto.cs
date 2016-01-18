using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain;
namespace Hyde.Domain.Model
{
    public class SanfenqiuproductDto : IEntityKey
    {
        public int key { get; set; }

        public int sanfenqiukey { get; set; }

    }
}