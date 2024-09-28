using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Business")]
public class Business
{
    [Column("BusinessId")] public byte Id { get; set; }

    [Column("BusinessName")] public string Name { get; set; }
}