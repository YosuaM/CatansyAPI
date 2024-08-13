using System;
using Microsoft.EntityFrameworkCore;
using CatansyAPI.Context;
using CatansyAPI.Repositories.Base.Interfaces;

namespace CatansyAPI.Repositories.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CatansyContext _catansyContext1;

    public GenericRepository(CatansyContext _catansyContext)
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
        await _catansyContext1.SaveChangesAsync();
    }
}
