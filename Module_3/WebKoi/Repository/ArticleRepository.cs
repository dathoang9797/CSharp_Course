using WebAppAuthentication.Model;
using WebKoi.Model;

namespace WebKoi.Repository;

public class ArticleRepository : BaseRepository
{
    public ArticleRepository(KoiContext context) : base(context)
    {
    }

    public List<Article> GetArticle()
    {
        return Context.Article.ToList();
    }

    public int Add(Article obj)
    {
        Context.Article.Add(obj);
        return Context.SaveChanges();
    }
}