using System;

namespace CatansyAPI.Repositories.Base.Interfaces;

public interface IGenericRepository<T> where T : class
{
    public Task AddAsync(T entity);
    public void Add(T entity);
}
