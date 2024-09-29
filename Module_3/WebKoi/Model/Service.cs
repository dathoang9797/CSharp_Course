using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Service")]
public class Service
{
    
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // [Key]
    [Column("ServiceId")] public byte Id { get; set; }

    [Column("ServiceName")] public string Name { get; set; }
}