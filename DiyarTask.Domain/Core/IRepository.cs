using System.Linq.Expressions;

namespace DiyarTask.Domain.Core;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);
}
