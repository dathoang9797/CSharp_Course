using System.Collections.Generic;
using System.Linq;
using WebKoi.Model;

namespace WebKoi.Repository;

public class ArticleRepository : BaseRepository
{
    public ArticleRepository(KoiContext context) : base(context)
    {
    }

    public List<Article> GetArticles()
    {
        return Context.Article.ToList();
    }
    
    public Article? GetArticle(int id)
    {
        return Context.Article.Find(id);
    }

    public int Add(Article obj)
    {
        Context.Article.Add(obj);
        return Context.SaveChanges();
    }
    
    public int Edit(Article obj)
    {
        Context.Article.Update(obj);
        return Context.SaveChanges();
    }
}