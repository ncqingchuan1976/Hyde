using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Hyde.Api.Models
{
    public class PageResult<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int ToTalPage { get; set; }

        public int TotalItem { get; set; }

        public IEnumerable<T> Entities { get; set; }
    }

    internal static class PageResultExtension
    {
        internal static PageResult<C> ToPageResult<T, C>(this IPagedList<T> source, IEnumerable<C> items)
        {
            return new PageResult<C>()
            {
                PageIndex = source.PageNumber,
                ToTalPage = source.PageCount,
                PageSize = source.PageSize,
                TotalItem = source.TotalItemCount,
                Entities = items
            };
        }
    }
}
