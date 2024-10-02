using WebKoi.Model;
using WebKoi.Models;

namespace WebKoi.Repository;

public class StatusRepository : BaseRepository
{
    public StatusRepository(KoiContext context) : base(context)
    {
    }

    public List<Status> GetStatus()
    {
        return Context.Status.ToList();
    }
}