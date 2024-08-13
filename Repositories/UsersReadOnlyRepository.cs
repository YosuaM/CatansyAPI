using CatansyAPI.Context;
using CatansyAPI.Entities;
using CatansyAPI.Repositories.Base;
using CatansyAPI.Repositories.Interfaces;

namespace CatansyAPI.Repositories;

public class UsersReadOnlyRepository(CatansyContext _catansyContext)
    : ReadOnlyGenericRepository<User>(_catansyContext), IUsersReadOnlyRepository
{
    public async Task<User?> SearchUserById(int id) 
        => await FindFirstOrDefaultAsync(x => x.Id == id);
}