using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Domain
{
    public enum ORDER_STATE
    {
        Create = 1,
        Sorting = 2,
        Cancled = 3


    }

    public enum STOCK_DIRECTOR
    {
        InStock = 1,
        OutStock = -1
    }
}
