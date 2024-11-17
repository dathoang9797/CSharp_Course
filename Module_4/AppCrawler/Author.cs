using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCrawler;

[Table("Author")]
public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthorKey { get; set; }
    
    [Column("AuthorId")] public int Id { get; set; }
    
    [Column("AuthorName"), MaxLength(64)] public string Name { get; set; } = null!;
    [MaxLength(64)] public string Slug { get; set; } = null!;
}