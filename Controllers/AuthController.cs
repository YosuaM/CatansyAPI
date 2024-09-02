using Catansy.API.Controllers.Base;
using Catansy.API.Models.Requests.Auth;
using Catansy.API.Models.Responses.Auth;
using Catansy.API.Models.Responses.Common;
using Catansy.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catansy.API.Controllers;

[Route("[controller]")]
public class AuthController : CatansyBaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(typeof(UserWithTokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser(CreateUserRequest req)
    {
        var response = await _authService.CreateUser(req.ToDto());
        return !response.IsSuccess ? ReturnResponseCode(response.Error) : Ok(response.Value);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(typeof(UserWithTokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Login(LoginRequest req)
    {
        var response = await _authService.Login(req);
        return !response.IsSuccess ? ReturnResponseCode(response.Error) : Ok(response.Value);
    }
}