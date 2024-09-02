using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Catansy.API.Context;
using Catansy.API.Repositories.Base.Interfaces;

namespace Catansy.API.Repositories.Base;

public class ReadOnlyGenericRepository<T> : IReadOnlyGenericRepository<T> where T : class
{
    private readonly CatansyContext _catansyContext1;

    protected ReadOnlyGenericRepository(CatansyContext _catansyContext)
    {
        _catansyContext1 = _catansyContext;
    }

    private DbSet<T> _entity => _catansyContext1.Set<T>();

    public T? FindFirstOrDefault(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null) 
        => InitialPredicate(select).FirstOrDefault(predicate);

    public List<T> Where(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null) 
        => InitialPredicate(select).Where(predicate).ToList();

    public async Task<T?> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null) 
        => await InitialPredicate(select).FirstOrDefaultAsync(predicate);

    public async Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null) 
        => await InitialPredicate(select).Where(predicate).ToListAsync();

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) 
        => await InitialPredicate().AnyAsync(predicate);

    private IQueryable<T> InitialPredicate(Expression<Func<T, T>>? select = null)
    {
        var query = _entity.AsNoTracking();
        
        if (select != null) 
        {
            query = query.Select(select);
        }

        return query;
    }
}
