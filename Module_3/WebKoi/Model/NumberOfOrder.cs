using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("NumberOfOrder")]
public class NumberOfOrder
{
    [Column("NumberOfOrderId")] public byte Id { get; set; }

    [Column("NumberOfOrderName")] public string Name { get; set; }
}