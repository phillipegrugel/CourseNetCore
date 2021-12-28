using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.Api.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCont { get; set; }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCont = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var skipCount = pageNumber > 0 ? (pageNumber-1) * pageSize : 0;

            var count = await source.CountAsync();
            var items = await source.Skip(skipCount)
                                    .Take(pageSize)
                                    .ToListAsync();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}