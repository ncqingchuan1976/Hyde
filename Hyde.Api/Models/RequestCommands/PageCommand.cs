using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Web.Http;
namespace Hyde.Api.Models.RequestCommands
{
    [FromUri]
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
        /// 页大小，默认为20，最小为1
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; } = 20;

    }
}
