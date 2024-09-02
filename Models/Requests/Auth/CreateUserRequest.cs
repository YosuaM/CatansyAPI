using System.Text.Json.Serialization;
using Catansy.API.Dtos.Users;

namespace Catansy.API.Models.Requests.Auth;

public class CreateUserRequest 
{
    public string? Mail {get;set;}
    public string? Password {get;set;}

    public CreateUserDto ToDto()
        => new(Mail, Password);
}