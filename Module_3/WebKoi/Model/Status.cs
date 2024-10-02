using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Models;

[Table("Status")]
public class Status
{
    public byte StatusId { get; set; }
    public string? StatusName { get; set; }
}