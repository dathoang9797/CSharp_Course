using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebAppFruitable.Model;

[Table("Category")]
public class Category
{
    public byte CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    [JsonIgnore]
    public List<Product> Products { get; set; }
}