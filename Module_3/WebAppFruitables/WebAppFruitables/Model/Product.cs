using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitables.Model;

[Table("Product")]
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public Category? Category { get; set; }
}