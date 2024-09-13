using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Match")]
public class Match
{
    public int MatchId { get; set; } 
    public byte RoundId { get; set; }
    public Round Round { get; set; }
    public short TeamId1 { get; set; }
    public short TeamId2 { get; set; }
    public Team Team1{ get; set; }
    public Team Team2{ get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public byte Score1 { get; set; }
    public byte Score2 { get; set; }
}