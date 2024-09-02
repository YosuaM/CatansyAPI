namespace Catansy.API.Models.Requests.Auth;

public class LoginRequest
{
    public string Mail { get; set; }
    public string Password { get; set; }
}