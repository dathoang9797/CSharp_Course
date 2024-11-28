namespace WebApp.Models;

public class Member
{
    public string MemberId { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string GivenName { get; set; } = null!;
    public string? SurName { get; set; }
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime LoginDate { get; set; }
}