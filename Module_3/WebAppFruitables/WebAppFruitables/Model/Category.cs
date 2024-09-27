using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitables.Model;

[Table("Category")]
public class Category
{
    public byte CategoryId { get; set; }
    public string CategoryName { get; set; }
}