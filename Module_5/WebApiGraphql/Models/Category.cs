using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGraphql.Models;

[Table("Category")]
public class Category
{
    [Column("CategoryId")]
    public short Id { get; set; }
    [Column("CategoryName")]
    public string? Name { get; set; }
}