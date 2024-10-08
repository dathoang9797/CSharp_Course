using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Member")]
public class Member
{
    public string? MemberId { get; set; }
    public string? Email { get; set; }
    public byte[]? Password { get; set; }
    public string? Name { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
}