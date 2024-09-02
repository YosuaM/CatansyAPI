using Catansy.API.Dtos.Users;
using Catansy.API.Models.Requests.Auth;
using Catansy.API.Models.Responses.Auth;
using Catansy.API.Models.Responses.Common;

namespace Catansy.API.Services.Interfaces;

public interface IAuthService
{
    Task<ResultResponse<UserWithTokenResponse, Error>> CreateUser(CreateUserDto req);
    Task<ResultResponse<UserWithTokenResponse, Error>> Login(LoginRequest req);
}