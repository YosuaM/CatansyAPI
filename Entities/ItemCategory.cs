using System.ComponentModel.DataAnnotations.Schema;

namespace Catansy.API.Entities;

[Table("items_categories")]
public class ItemCategory
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
}