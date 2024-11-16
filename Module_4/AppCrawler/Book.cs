using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppCrawler;

[Table("Book")]
public class Book
{
    [Column("BookId")]
    public int Id { get; set; }
    [JsonPropertyName("master_id")] public int MasterId { get; set; }
    public string Sku { get; set; } = null!;
    
    [Column("BookName")]
    public string Name { get; set; } = null!;
    [JsonPropertyName("url_key")] public string UrlKey { get; set; } = null!;

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; } = null!;

    [JsonPropertyName("original_price")] 
    public int OriginalPrice { get; set; }
    
    public string Icon { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<Image> Images { get; set; } = null!;
    public int Discount { get; set; }
    [JsonPropertyName("discount_rate")] 
    public int DiscountRate { get; set; }
    
    public decimal RatingAverage { get; set; }
    
    [JsonPropertyName("review_count")] 
    public int ReviewCount { get; set; }
    
    [JsonPropertyName("favourite_count")] 
    public int FavouriteCount { get; set; }
    
    public List<Author> Authors { get; set; } = null!;
    public List<BookAttribute> Specifications { get; set; } = null!;
    public Category Categories { get; set; } = null!;
}