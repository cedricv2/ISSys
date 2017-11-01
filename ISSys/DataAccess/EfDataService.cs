using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InventorySystem.DataAccess.EntityFramework;

namespace InventorySystem.DataAccess
{
    public class EfDataService<T> : IDataService<T> where T : class, new()
    {
        //public async Task<List<T>> GetRangeAsync()
        //{
        //    return await GetRangeAsync(CancellationToken.None);
        //}

        public async Task<List<T>> GetRangeAsync(CancellationToken token)
        {
            return await Task.Run(async () =>
            {
                using (var context = new InventoryContext())
                {
                    return await context.Set<T>().ToListAsync(token).ConfigureAwait(false);
                }
            });
        }

        public async Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> condition)
        {
            return await Task.Run(async () =>
            {
                using (var context = new InventoryContext())
                {
                    return await context.Set<T>().Where(condition).ToListAsync().ConfigureAwait(false);
                }
            });
        }

        public async Task AddASync(T record, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new InventoryContext())
                {
                    context.Set<T>().Add(record);
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public async Task RemoveASync(T record, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new InventoryContext())
                {
                    context.Entry(record).State = EntityState.Deleted;
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }

        public async Task UpdateASync(T record, CancellationToken token)
        {
            await Task.Run(async () =>
            {
                using (var context = new InventoryContext())
                {
                    context.Entry(record).State = EntityState.Modified;
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }, token);
        }
    }
}
