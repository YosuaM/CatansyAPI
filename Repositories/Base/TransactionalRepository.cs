using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Catansy.API.Context;
using Catansy.API.Repositories.Base.Interfaces;

namespace Catansy.API.Repositories.Base;

public class TransactionalRepository<T> : ITransactionalRepository<T> where T : class
{
    private readonly CatansyContext _catansyContext1;

    protected TransactionalRepository(CatansyContext _catansyContext)
    {
        _catansyContext1 = _catansyContext;
    }

    private DbSet<T> _entity => _catansyContext1.Set<T>();

    public void Add(T entity)
    {
        _entity.Add(entity);
        _catansyContext1.SaveChanges();
    }

    public async Task AddAsync(T entity)
    {
        await _entity.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _catansyContext1.SaveChangesAsync();
    }
    
    public async Task<T?> FindFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>>? select = null) 
        => await InitialPredicate(select).FirstOrDefaultAsync(predicate);
    
    private IQueryable<T> InitialPredicate(Expression<Func<T, T>>? select = null)
    {
        var query = _entity.AsQueryable();
        
        if (select != null) 
        {
            query = query.Select(select);
        }

        return query;
    }
}
