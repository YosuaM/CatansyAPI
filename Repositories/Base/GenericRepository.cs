using System;
using Microsoft.EntityFrameworkCore;
using CatansyAPI.Context;
using CatansyAPI.Repositories.Base.Interfaces;

namespace CatansyAPI.Repositories.Base;

public class GenericRepository<T>(CatansyContext _catansyContext) : IGenericRepository<T> where T : class
{
    private DbSet<T> _entity => _catansyContext.Set<T>();

    public void Add(T entity)
    {
        _entity.Add(entity);
        _catansyContext.SaveChanges();
    }

    public async Task AddAsync(T entity)
    {
        await _entity.AddAsync(entity);
        await _catansyContext.SaveChangesAsync();
    }
}
