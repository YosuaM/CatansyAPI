using System;
using System.Linq.Expressions;

namespace CatansyAPI.Repositories.Base.Interfaces;

public interface IReadOnlyGenericRepository<T> where T : class
{
    T? FindFirstOrDefault(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null);
    List<T> Where(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null);
    Task<T?> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null);
    Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null);
}
