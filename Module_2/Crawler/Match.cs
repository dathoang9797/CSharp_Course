namespace Crawler;

public class Match
{
    public string Date { get; set; } = null!;
    public string Team1 { get; set; } = null!;
    public string Team2 { get; set; } = null!;
    public byte Goals1 { get; set; }
    public byte Goals2 { get; set; }
    public string Stadium { get; set; } = null!;
    public override string ToString()
    {
        return $"{Team1}-{Team2}";
    }
}