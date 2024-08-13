using CatansyAPI.Dtos.Users;
using CatansyAPI.Repositories.Interfaces;
using CatansyAPI.Services.Interfaces;

namespace CatansyAPI.Services;

public class UsersService : IUsersService
{
    private readonly IUsersReadOnlyRepository _usersRoRepository1;

    public UsersService(IUsersReadOnlyRepository _usersRoRepository)
    {
        _usersRoRepository1 = _usersRoRepository;
    }

    public async Task<UserDto?> SearchUserById(int id)
    {
        var user = await _usersRoRepository1.SearchUserById(id);
        return user?.ToDto();
    }
}