namespace WebAppChat.Model;

public class Member
{
    public string MemberId { get; set; }
    public string GivenName { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
}