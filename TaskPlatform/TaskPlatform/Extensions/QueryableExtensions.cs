using Microsoft.EntityFrameworkCore;
using TaskPlatform.Common;

namespace TaskPlatform.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPagedAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            var total = await query.CountAsync();

            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<T>
            {
                Total = total,
                Items = items
            };
        }
    }
}
