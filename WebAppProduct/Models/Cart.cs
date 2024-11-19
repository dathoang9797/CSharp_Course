using System.ComponentModel.DataAnnotations;

namespace WebAppProduct.Models;

public class Cart
{
    public int CartId { get; set; }
    [Required] [StringLength(32)] public string CartCode { get; set; } = string.Empty;
    public int ProductId { get; set; }
    public virtual Product? Product { get; set; }
    [Required] [Range(1, 32767)] public short Quantity { get; set; }
}