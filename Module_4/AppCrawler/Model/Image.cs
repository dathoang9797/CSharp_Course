using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppCrawler;

[Table("Image")]
public class Image
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ImageId")]
    public int ImageId { get; set; }

    [JsonPropertyName("base_url")] public string BaseUrl { get; set; } = null!;
    [JsonPropertyName("large_url")] public string LargeUrl { get; set; } = null!;
    [JsonPropertyName("medium_url")] public string MediumUrl { get; set; } = null!;
    [JsonPropertyName("small_url")] public string SmallUrl { get; set; } = null!;
    [JsonPropertyName("thumbnail_url")] public string ThumbnailUrl { get; set; } = null!;
}