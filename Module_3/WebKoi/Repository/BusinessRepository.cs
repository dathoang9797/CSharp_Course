using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebKoi.Model;

namespace WebKoi.Repository;

public class BusinessRepository : BaseRepository
{
    public BusinessRepository(KoiContext context) : base(context)
    {
    }

    public List<Business> GetBusiness()
    {
        return Context.Business.ToList();
    }
}