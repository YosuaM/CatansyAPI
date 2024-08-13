using CatansyAPI.Dtos.Users;

namespace CatansyAPI.Services.Interfaces;

public interface IUsersService
{
    Task<UserDto?> SearchUserById(int id);
}