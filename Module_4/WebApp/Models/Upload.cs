namespace WebApp.Models;

public class Upload
{
    public int UploadId { get; set; }
    public string? ImageUrl { get; set; }
    public string? OriginalName { get; set; }
    public string? Type { get; set; }
    public long Size { get; set; }
    public DateTime UploadDate { get; set; }
}