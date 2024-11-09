using System.Text.Json.Serialization;

namespace DAL;

public class Product
{
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public string? ShortDescription { get; set; }
    public int? BestSellingRank { get; set; }
    public string? ThumbnailImage { get; set; }
    public int ManufacturerId { get; set; }
    public string? Image { get; set; }
    public int ProductTypeId { get; set; }
    public string? Shipping { get; set; }
    public decimal SalePrice { get; set; }
    [JsonPropertyName("salePrice_range")] public string? SalePriceRange { get; set; }
    public int? CustomerReviewCount { get; set; }
}