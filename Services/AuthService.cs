using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Catansy.API.Dtos.Users;
using Catansy.API.Entities;
using Catansy.API.Models.Requests.Auth;
using Catansy.API.Models.Responses.Auth;
using Catansy.API.Models.Responses.Common;
using Catansy.API.ResultErrors.Auth;
using Catansy.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Catansy.API.Services;

public class AuthService : IAuthService
{
    private readonly IUsersService _usersService;
    private readonly IConfiguration _configuration;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogger<AuthService> _logger;
    
    public AuthService(IUsersService usersService, IConfiguration configuration, IPasswordHasher passwordHasher, ILogger<AuthService> logger)
    {
        _usersService = usersService;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
        _logger = logger;
    }

    public async Task<ResultResponse<UserWithTokenResponse, Error>> CreateUser(CreateUserDto req)
    {
        if (await _usersService.UserExistsByMail(req.Mail.ToLower()))
        {
            return CreateUserErrors.MailAlreadyExits;
        }
        
        var newUser = User.CreateUser(req, _passwordHasher.HashPassword(req.Password));
        await _usersService.CreateUser(newUser);
        
        _logger.LogInformation("New user created successfully: {NewUserMail} - {NewUserUid}", newUser.Mail, newUser.Uid);
        
        return GenerateUserWithToken(newUser);
    }
    
    public async Task<ResultResponse<UserWithTokenResponse, Error>> Login(LoginRequest req)
    {
        var user = await _usersService.SearchUserByMail(req.Mail.ToLower());

        if (user == null)
        {
            return LoginErrors.UserIncorrectPasswordOrNotFound;
        }

        if (!_passwordHasher.ValidatePassword(user.Password, req.Password))
        {
            return LoginErrors.UserIncorrectPasswordOrNotFound;
        }

        if (user.IsBanned)
        {
            return LoginErrors.UserIsBanned;
        }
        
        user.UpdateLastAccess();
        
        await _usersService.SaveUser();

        return GenerateUserWithToken(user);
    }
    
    private UserWithTokenResponse GenerateUserWithToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
            new (ClaimTypes.NameIdentifier, user.Uid)
        };
    
        var token = new JwtSecurityToken
        (
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );

        return new UserWithTokenResponse()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Id = user.Uid
        };
    }
}