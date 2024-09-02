using Catansy.API.Context;
using Catansy.API.Entities;
using Catansy.API.Repositories.Base;
using Catansy.API.Repositories.Interfaces;

namespace Catansy.API.Repositories;

public class UsersReadOnlyRepository : ReadOnlyGenericRepository<User>, IUsersReadOnlyRepository
{
    public UsersReadOnlyRepository(CatansyContext _catansyContext) : base(_catansyContext)
    {
    }

    public async Task<User?> SearchUserById(int id) 
        => await FindFirstOrDefaultAsync(x => x.Id == id);
}