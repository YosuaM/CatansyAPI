namespace Catansy.API.Dtos.Users;

public record UpdateUserDto(string Mail, string Password, bool Banned);
