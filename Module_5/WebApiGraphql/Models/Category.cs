using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGraphql.Models;

[Table("Category")]
public class Category
{
    [Column("CategoryId")]
    public int Id { get; set; }
    [Column("CategoryName")]
    public string? Name { get; set; }
}