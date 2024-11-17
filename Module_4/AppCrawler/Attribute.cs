using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCrawler;

[Table("Attribute")]
public class Attribute
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AttributeKey { get; set; }
    
    [Column("AttributeCode")] 
    public string Code { get; set; } = null!;

    [Column("AttributeName"), MaxLength(64)]
    public string Name { get; set; } = null!;

    [MaxLength(64)]
    public string Value { get; set; } = null!;
}