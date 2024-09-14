using WebAppAuthentication.Model;

namespace WebAppAuthentication.Repository;

public abstract class BaseRepository
{
    protected StoreContext Context { get; set; }

    public BaseRepository(StoreContext context)
    {
        Context = context;
    }
}