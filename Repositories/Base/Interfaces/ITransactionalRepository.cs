using System;
using System.Linq.Expressions;

namespace Catansy.API.Repositories.Base.Interfaces;

public interface ITransactionalRepository<T> where T : class
{
    public Task AddAsync(T entity);
    public void Add(T entity);
    Task<T?> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null);
    Task SaveChangesAsync();
}
