using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppProduct.Models;

[Table("Customer")]
public class Customer
{
    [Column("CustomerId")] public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Job { get; set; }
    public byte RoleId { get; set; }
    public byte ServiceId { get; set; }
    public byte NumberOfOrderId { get; set; }
    public byte BusinessId { get; set; }
    public string? Description { get; set; }
}