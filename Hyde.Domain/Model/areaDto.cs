using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.Domain.Model
{
    /// <summary>
    /// 区域
    /// </summary>
    public class areaDto : IEntityKey
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int key
        {
            get;

            set;
        }
        /// <summary>
        /// 区域编码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public int? pid { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string zip { get; set; }

        public virtual List<areaDto> children { get; set; }

        
    }
}
