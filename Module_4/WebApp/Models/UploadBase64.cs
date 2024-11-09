namespace WebApp.Models;

public class UploadBase64
{
    public int Id { get; set; }
    public byte[]? Image { get; set; }
    public DateTime UploadDate { get; set; }
}