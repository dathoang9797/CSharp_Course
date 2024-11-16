using System.Text.Json.Serialization;

namespace AppCrawler;

public class Book
{
    public int Id { get; set; }
    [JsonPropertyName("master_id")] public int MasterId { get; set; }
    public string Sku { get; set; } = null!;
    public string Name { get; set; } = null!;
    [JsonPropertyName("url_key")] public string UrlKey { get; set; } = null!;

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; } = null!;
    [JsonPropertyName("original_price")] public int OriginalPrice { get; set; }
    public string Icon { get; set; } = null!;
    public string Description { get; set; } = null!;
    
}