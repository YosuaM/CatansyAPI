namespace Catansy.API.Dtos.Users;

public record UserDto
{
    public int Id { get; set; }
    public string Uid { get; set; }
    public string Mail { get; set; }
    public string? Password { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? LastAccess { get; set; }
    public bool? Banned { get; set; }
    public int? Language { get; set; }
}