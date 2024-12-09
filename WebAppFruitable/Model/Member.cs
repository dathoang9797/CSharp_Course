using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitable.Model;

public class Member
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

public class MemberEntity
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
    [Column(TypeName = "binary(64)")]
    public byte[] Password { get; set; } = Array.Empty<byte>();
}