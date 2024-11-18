namespace WebApp.Models;

public class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public short Quantity { get; set; }
    public string ImageUrl { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public int Viewed { get; set; }
}