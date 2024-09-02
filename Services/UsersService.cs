using Catansy.API.Dtos.Users;
using Catansy.API.Entities;
using Catansy.API.Repositories.Interfaces;
using Catansy.API.Services.Interfaces;

namespace Catansy.API.Services;

public class UsersService : IUsersService
{
    private readonly IUsersReadOnlyRepository _readOnlyRepository;
    private readonly IUsersTransactionalRepository _transactionalRepository;

    public UsersService(IUsersReadOnlyRepository readOnlyRepository, IUsersTransactionalRepository transactionalRepository)
    {
        _readOnlyRepository = readOnlyRepository;
        _transactionalRepository = transactionalRepository;
    }

    public async Task<UserDto?> SearchUserByIdRO(int id)
    {
        var user = await _readOnlyRepository.SearchUserById(id);
        return user?.ToDto();
    }

    public async Task<bool> UserExistsByMail(string mail) 
        => await _readOnlyRepository.AnyAsync(x => x.Mail == mail);

    public async Task CreateUser(User user) 
        => await _transactionalRepository.CreateUser(user);

    public async Task<User?> SearchUserByMail(string mail) 
        => await _transactionalRepository.SearchUserByMail(mail, includeBanned: true);

    public async Task SaveUser() 
        => await _transactionalRepository.SaveChangesAsync();
}