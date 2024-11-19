using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppProduct.Models;

[Table("Member")]
public class Member
{
    [Key] [StringLength(32)] public string MemberId { get; set; } = string.Empty;
    [Required] [StringLength(32)] public string Name { get; set; } = string.Empty;
    [Required] [StringLength(16)] public string GivenName { get; set; } = string.Empty;
    [StringLength(32)] public string? Surname { get; set; }

    [Required]
    [StringLength(64)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required] [StringLength(128)] public string Password { get; set; } = string.Empty;

    [StringLength(16)] public string? Phone { get; set; }

    [Required]
    [StringLength(16)]
    [RegularExpression(@"^(Member|Admin)$")]
    public string Role { get; set; } = "Member";

    [Required] public bool IsOnline { get; set; } = false;
    [Required] public DateTime LoginDate { get; set; } = DateTime.Now;
    [Required] public DateTime RegisterDate { get; set; } = DateTime.Now;
}