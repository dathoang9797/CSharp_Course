using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Status")]
public class Status
{
    public short StatusId { get; set; }
    public string? StatusName { get; set; }
}