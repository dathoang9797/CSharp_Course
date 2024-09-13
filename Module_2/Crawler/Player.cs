namespace Crawler;

public class Player
{
    public short TeamId { get; set; }
    public string FullName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string ClubName { get; set; } = null!;
    public short Goals { get; set; }
    public short Caps { get; set; }
}