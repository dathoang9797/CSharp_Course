using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebAppFruitable.Model;

[Table("Product")]
public class Product
{
    [Key] public int ProductId { get; set; }

    [Required] [ForeignKey("Category")] public byte CategoryId { get; set; }

    [Required] [MaxLength(128)] public string ProductName { get; set; }

    [Required] [MaxLength(32)] public string ImageUrl { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [Required] [MaxLength(1024)] public string Description { get; set; }

    [Range(1, 5)] public byte Rating { get; set; } = 5;

    [JsonIgnore]
    public virtual Category Category { get; set; }
}

public class ProductForm
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public byte Rating { get; set; }
    public byte CategoryId { get; set; }
}

public class ProductFormEdit : ProductForm
{
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
}

public class ProductFormDelete : ProductForm
{
    public int ProductId { get; set; }
}