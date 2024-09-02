namespace Catansy.API.Services.Interfaces;

public interface IPasswordHasher
{
    string HashPassword(string password);
    bool ValidatePassword(string password, string passwordToCompare);
}