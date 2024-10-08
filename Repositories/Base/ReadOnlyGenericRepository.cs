using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CatansyAPI.Context;
using CatansyAPI.Repositories.Base.Interfaces;

namespace CatansyAPI.Repositories.Base;

public class ReadOnlyGenericRepository<T> : IReadOnlyGenericRepository<T> where T : class
{
    private readonly CatansyContext _catansyContext1;

    public ReadOnlyGenericRepository(CatansyContext _catansyContext)
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
