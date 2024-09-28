using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Role")]
public class Role
{
    [Column("RoleId")] public byte Id { get; set; }

    [Column("RoleName")] public string Name { get; set; }
}