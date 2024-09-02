using Catansy.API.Dtos.Users;
using Catansy.API.Entities;

namespace Catansy.API.Services.Interfaces;

public interface IUsersService
{
    Task<UserDto?> SearchUserByIdRO(int id);
    Task<bool> UserExistsByMail(string mail);
    Task CreateUser(User user);
    Task<User?> SearchUserByMail(string mail);
    Task SaveUser();
}