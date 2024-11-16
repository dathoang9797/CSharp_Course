using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AppCrawler;

[Table("Category")]
public class Category
{
    [Column("CategoryId")] 
    public int Id { get; set; }
    
    [Column("CategoryName")] 
    public string Name { get; set; } = null!;
    
    [JsonPropertyName("is_leaf")] public bool IsLeaf { get; set; }
}