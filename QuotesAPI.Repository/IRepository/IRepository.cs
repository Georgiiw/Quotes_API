using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuotesAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();

    }
}
