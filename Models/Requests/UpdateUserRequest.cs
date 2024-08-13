using System;
using CatansyAPI.Dtos.Users;

namespace CatansyAPI.Models.Requests;

public class UpdateUserRequest
{
    public string Mail {get;set;}
    public string Password {get;set;}
    public bool Banned {get;set;}

    public UpdateUserDto ToDto()
        => new(Mail, Password, Banned);
}
