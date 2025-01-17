using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCrawler;

[Table("BookAttribute")]
public class BookAttribute
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BookAttributeId")] 
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    public List<Attribute> Attributes { get; set; } = null!;
}