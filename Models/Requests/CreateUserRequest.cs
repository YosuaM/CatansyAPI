using CatansyAPI.Dtos.Users;

namespace CatansyAPI.Models.Requests;

public class CreateUserRequest 
{
    public string Mail {get;set;}
    public string Password {get;set;}

    public CreateUserDto ToDto()
        => new(Mail, Password);
}