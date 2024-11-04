using System.Text.Json.Serialization;

namespace DAL;

public class Product
{
    [JsonPropertyName("objectID")] public int ProductId { get; set; }
    [JsonPropertyName("name")] public string? ProductName { get; set; }
    public string? ShortDescription { get; set; }
    public byte? BestSellingRank { get; set; }
    public string? ThumbnailImage { get; set; }
    public string? Manufacturer { get; set; }
    public string? Url { get; set; }
    public string? Image { get; set; }
    public string? Type { get; set; }
    public string? Shipping { get; set; }
    [JsonPropertyName("salePrice_range")] public string? SalePriceRange { get; set; }
    public decimal? CustomerReviewCount { get; set; }
    public List<string> Categories { get; set; }
}