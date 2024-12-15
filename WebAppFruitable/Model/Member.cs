using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitable.Model;

public class Member
{
    [Key]
    [Required]
    [Column(TypeName = "char(32)")]
    public string MemberId { get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]
    [Column(TypeName = "nvarchar(16)")]
    public string GivenName { get; set; } = string.Empty;

    [Required]
    [MaxLength(32)]
    [Column(TypeName = "nvarchar(32)")]
    public string Surname { get; set; } = string.Empty;

    [Required]
    [MaxLength(64)]
    [Column(TypeName = "varchar(64)")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? LoginDate { get; set; }
    
    [MaxLength(128)]
    public string? ResetToken { get; set; }
    public DateTime? ResetTokenExpiry { get; set; }
    public byte[] Password { get; set; } = []; 
}

public class MemberBody
{
    public string? MemberId { get; set; }
    public string Password { get; set; } = null!;
    public string GivenName { get; set; } = null!;
    public string? SurName { get; set; }
    public string Email { get; set; } = null!;
    
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? LoginDate { get; set; }
}