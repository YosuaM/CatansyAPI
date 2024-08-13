using CatansyAPI.Dtos.Users;
using CatansyAPI.Repositories.Interfaces;
using CatansyAPI.Services.Interfaces;

namespace CatansyAPI.Services;

public class UsersService(IUsersReadOnlyRepository _usersRoRepository) : IUsersService
{
    public async Task<UserDto?> SearchUserById(int id)
    {
        var user = await _usersRoRepository.SearchUserById(id);
        return user?.ToDto();
    }
}