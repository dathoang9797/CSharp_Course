using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Model;

[Table("Article", Schema = "Blog")]
public class Article
{
    public int ArticleId { get; set; }
    public string? MemberId { get; set; }
    public string? ArticleName { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? Content { get; set; }
    public string? Body { get; set; }
    public DateTime ArticleDate { get; set; }
}