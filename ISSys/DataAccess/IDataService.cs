using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InventorySystem.DataAccess
{
    public interface IDataService<T> where T : class
    {
        Task<List<T>> GetRangeAsync(CancellationToken token);

        Task<List<T>> GetRangeAsync(Expression<Func<T, bool>> condition);

        Task AddASync(T record, CancellationToken token);

        Task RemoveASync(T record, CancellationToken token);

        Task UpdateASync(T record, CancellationToken token);
    }
}
