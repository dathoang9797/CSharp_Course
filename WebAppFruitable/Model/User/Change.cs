namespace WebAppFruitable.Model;

public class Change
{
    public string UserId { get; set; }
    public string? OldPassword { get; set; }
    public string? NewPassword { get; set; }
}