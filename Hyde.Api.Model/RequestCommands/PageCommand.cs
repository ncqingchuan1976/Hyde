using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Model.Validation;
using System.ComponentModel.DataAnnotations;

namespace Hyde.Api.Model.RequestCommands
{

    /// <summary>
    /// 请求分页类
    /// </summary>
    public class PageCommand : IRequestCommand
    {
        /// <summary>
        /// 页序号默认1，最小为1
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 页大小，默认为10，最小1，最大100
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 20;

    }
}
