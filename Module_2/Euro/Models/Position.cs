using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Position")]
public class Position
{
    public byte PositionId { get; set; }
    public string PositionName { get; set; }
}