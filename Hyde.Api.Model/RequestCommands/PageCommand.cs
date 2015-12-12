using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Model.Validation;
using System.ComponentModel.DataAnnotations;
namespace Hyde.Api.Model.RequestCommands
{
    public class PageCommand : IRequestCommand
    {
        [Minimum(1)]
        public int PageIndex { get; set; } = 1;
        [Minimum(10)]
        [Maximum(100)]
        public int PageSize { get; set; } = 10;

    }
}
