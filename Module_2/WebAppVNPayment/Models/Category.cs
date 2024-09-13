using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppVNPayment.Models;

[Table("Category")]
public class Category
{
    public short CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public string? CategoryAlias { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}