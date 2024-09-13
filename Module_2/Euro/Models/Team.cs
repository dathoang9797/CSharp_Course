using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Team")]
public class Team
{
    public short TeamId { get; set; }
    public string TeamName { get; set; } = null!;
    public string GroupName { get; set; } = null!;
    public List<Match> TeamMatches1 { get; set; }
    public List<Match> TeamMatches2 { get; set; }
}