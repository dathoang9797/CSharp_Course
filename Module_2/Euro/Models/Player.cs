using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Player")]
public class Player
{
    public int PlayerId { get; set; }
    public short TeamId { get; set; }
    public short ClubId { get; set; }
    public byte PositionId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte Number { get; set; }
    public string Photo { get; set; } = null!;
}