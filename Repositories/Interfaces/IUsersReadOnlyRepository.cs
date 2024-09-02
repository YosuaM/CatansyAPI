using Catansy.API.Entities;
using Catansy.API.Repositories.Base.Interfaces;

namespace Catansy.API.Repositories.Interfaces;

public interface IUsersReadOnlyRepository : IReadOnlyGenericRepository<User>
{
    Task<User?> SearchUserById(int id);
}