using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebAppFruitable.Model;

[Table("Category")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    [JsonIgnore]
    public List<Product> Products { get; set; }
}

public class CategoryForm
{
    public string CategoryName { get; set; }
}

public class CategoryUpdate
{
    public byte CategoryId { get; set; }
    public string CategoryName { get; set; }
}


public class CategoryFormDelete
{
    public byte CategoryId { get; set; }
}