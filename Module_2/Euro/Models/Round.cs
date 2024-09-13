using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Round")]
public class Round
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public byte RoundId { get; set; }
    public string RoundName { get; set; } = null!;
    // public List<Match> Matchs { get; set; }
}