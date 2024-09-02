using Catansy.API.Context;
using Catansy.API.Entities;
using Catansy.API.Repositories.Base;
using Catansy.API.Repositories.Interfaces;

namespace Catansy.API.Repositories;

public class UsersTransactionalRepository : TransactionalRepository<User>, IUsersTransactionalRepository
{
    public UsersTransactionalRepository(CatansyContext _catansyContext) : base(_catansyContext)
    {}

    public async Task CreateUser(User entity)
    {
        await AddAsync(entity);
    }

    public async Task<User?> SearchUserByMail(string mail, bool includeBanned = false)
    {
        return await FindFirstOrDefaultAsync(x => x.Mail == mail && (x.Banned == false || x.Banned == includeBanned));
    }
}