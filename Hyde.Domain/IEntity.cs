using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Domain
{

    public interface IEntityKey
    {
        /// <summary>
        /// 实体主键
        /// </summary>
        int key { get; set; }
    }

    public interface IRowversion
    {
        /// <summary>
        /// Timestap,并发控制标志
        /// </summary>
        byte[] lastchanged { get; set; }
    }
}
