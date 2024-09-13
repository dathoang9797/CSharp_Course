namespace WebAppStore.Model;

public class ChangeModel
{
    public string UserId { get; set; }
    public string? OldPassword { get; set; }
    public string? NewPassword { get; set; }
}