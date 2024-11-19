using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppProduct.Models;

[Table("Customer")]
public class Customer
{
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(64)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [MaxLength(64)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(64)]
    public string Job { get; set; } = string.Empty;

    [Required]
    [Range(0, 255)]
    public byte RoleId { get; set; }

    [Required]
    [Range(0, 255)]
    public byte ServiceId { get; set; }

    [Required]
    [Range(0, 255)]
    public byte NumberOfOrderId { get; set; }

    [Required]
    [Range(0, 255)]
    public byte BusinessId { get; set; }

    [Required]
    [MaxLength(1024)]
    public string Description { get; set; } = string.Empty;
}