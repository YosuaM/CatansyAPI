using System.ComponentModel.DataAnnotations.Schema;
using CatansyAPI.Dtos.Users;

namespace CatansyAPI.Entities;

[Table("users")]
public class User
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("u_id")]
    public string Uid { get; set; }
    
    [Column("mail")]
    public string Mail { get; set; }
    
    [Column("password")]
    public string? Password { get; set; }
    
    [Column("created")]
    public DateTime? Created { get; set; }
    
    [Column("last_access")]
    public DateTime? LastAccess { get; set; }
    
    [Column("banned")]
    public bool? Banned { get; set; }
    
    [Column("language")]
    public int? Language { get; set; }

    public static User CreateUser(CreateUserDto req) =>
        new()
        {
            Mail = req.Mail,
            Uid = Guid.NewGuid().ToString(),
            Password = req.Password,
            Created = DateTime.UtcNow
        };

    public void UpdateUser(UpdateUserDto dto)
    {
        Mail = dto.Mail;
        Password = dto.Password;
        Banned = dto.Banned;
    }

    public UserDto ToDto() =>
        new()
        {
            Id = Id,
            Uid = Uid,
            Created = Created,
            Password = Password,
            Banned = Banned,
            Language = Language,
            LastAccess = LastAccess,
            Mail = Mail
        };
}