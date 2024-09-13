using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Models;

[Table("Club")]
public class Club
{
    public short Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
}