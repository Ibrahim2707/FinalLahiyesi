using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Repositories
{
    public interface IGenericRepository<T> where T: class,  new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Func<T, bool> expression);
        void Remove(T entity);
        Task<int> SaveAsync();
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> GetWithPagination(int page, int take);
        Task<bool> IsExistAsync(int id);
        Task<bool> RemoveAsync(int id);
    }
}
