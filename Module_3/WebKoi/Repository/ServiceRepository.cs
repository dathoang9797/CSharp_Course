using WebKoi.Model;

namespace WebKoi.Repository;

public class ServiceRepository : BaseRepository
{
    public ServiceRepository(KoiContext context) : base(context)
    {
    }

    public List<Service> GetService()
    {
        return Context.Services.ToList();
    }
}