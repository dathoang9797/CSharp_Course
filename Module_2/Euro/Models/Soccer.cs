using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Soccer")]
public class Soccer
{
    public int SoccerId  { get; set; }
    public string Name { get; set; } = null!;
    public string Position { get; set; } = null!;
    public byte Age { get; set; }
    public string Club { get; set; } = null!;
    public short Height { get; set; }
    public string Foot { get; set; }
    public short Caps { get; set; }
    public byte Goals { get; set; }
    public long MarketValue { get; set; }
    public string Country { get; set; } = null!;
}