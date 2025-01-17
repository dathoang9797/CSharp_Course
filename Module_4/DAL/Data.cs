using System.Text.Json.Serialization;

namespace DAL;

public class Data
{
    public int ObjectID { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public int? BestSellingRank { get; set; }
    public string? ThumbnailImage { get; set; }
    public string? Manufacturer { get; set; }
    public string? Image { get; set; }
    public string? Type { get; set; }
    public string? Shipping { get; set; }
    public decimal SalePrice { get; set; }
    [JsonPropertyName("salePrice_range")] public string? SalePriceRange { get; set; }
    public int? CustomerReviewCount { get; set; }
    public List<string> Categories { get; set; }
}