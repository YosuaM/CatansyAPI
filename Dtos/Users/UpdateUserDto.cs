namespace CatansyAPI.Dtos.Users;

public record class UpdateUserDto(string Mail, string Password, bool Banned);
