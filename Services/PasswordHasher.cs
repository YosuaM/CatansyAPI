using Catansy.API.Services.Interfaces;

namespace Catansy.API.Services;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password) 
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool ValidatePassword(string password, string passwordToCompare) 
        => BCrypt.Net.BCrypt.Verify(passwordToCompare, password);
}