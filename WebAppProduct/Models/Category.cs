using System.ComponentModel.DataAnnotations;

namespace WebAppProduct.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required] [MaxLength(100)] public string? CategoryName { get; set; }
}