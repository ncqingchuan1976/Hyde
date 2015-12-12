using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Domain
{
    public interface IEntityKey
    {
        int key { get; set; }
    }

    public interface IRowversion
    {
        byte[] lastchanged { get; set; }
    }
}
