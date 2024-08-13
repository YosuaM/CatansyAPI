using CatansyAPI.Entities;
using CatansyAPI.Repositories.Base.Interfaces;

namespace CatansyAPI.Repositories.Interfaces;

public interface IUsersReadOnlyRepository : IReadOnlyGenericRepository<User>
{
    Task<User?> SearchUserById(int id);
}