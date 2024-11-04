using System;
using WebKoi.Model;
using WebKoi.Models;

namespace WebKoi.Repository;

public class RecommendRepository : BaseRepository
{
    public RecommendRepository(KoiContext context) : base(context)
    {
    }

    public int Add(Recommend obj)
    {
        obj.Id = Guid.NewGuid().ToString().Replace("-", "");
        Context.Recommend.Add(obj);
        return Context.SaveChanges();
    }
}