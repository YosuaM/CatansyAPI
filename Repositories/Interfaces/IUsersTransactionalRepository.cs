using Catansy.API.Entities;
using Catansy.API.Repositories.Base.Interfaces;

namespace Catansy.API.Repositories.Interfaces;

public interface IUsersTransactionalRepository : ITransactionalRepository<User>
{
    Task CreateUser(User entity);
    Task<User?> SearchUserByMail(string mail, bool includeBanned = false);
}