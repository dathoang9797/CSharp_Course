using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Recommend")]
public class Recommend
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? Phone { get; set; }
}