using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAuthentication.Model;

[Table("Member")]
public class Member
{
    public string? MemberId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
}