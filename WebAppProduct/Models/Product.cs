using System.ComponentModel.DataAnnotations;

namespace WebAppProduct.Models;

public class Product
{
    public int ProductId { get; set; }
    [Required] [MaxLength(100)] public string ProductName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    [Required] [Range(0, 9999999999.99)] public decimal Price { get; set; }

    [Required] [MaxLength(50)] public string Brand { get; set; } = string.Empty;

    public string? Specifications { get; set; }

    [Range(0, int.MaxValue)] public int StockQuantity { get; set; } = 0;

    [Required] public DateTime CreatedDate { get; set; } = DateTime.Now;
}