using WebKoi.Model;

namespace WebKoi.Repository;

public abstract class BaseRepository
{
    protected KoiContext Context { get; set; }

    public BaseRepository(KoiContext context)
    {
        Context = context;
    }
}