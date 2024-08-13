using CatansyAPI.Context;
using CatansyAPI.Entities;
using CatansyAPI.Repositories.Base;
using CatansyAPI.Repositories.Interfaces;

namespace CatansyAPI.Repositories;

public class UsersReadOnlyRepository : ReadOnlyGenericRepository<User>, IUsersReadOnlyRepository
{
    public UsersReadOnlyRepository(CatansyContext _catansyContext) : base(_catansyContext)
    {
    }

    public async Task<User?> SearchUserById(int id) 
        => await FindFirstOrDefaultAsync(x => x.Id == id);
}