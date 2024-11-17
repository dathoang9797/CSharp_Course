using WebAppProduct.Models;

namespace WebAppProduct.Repository;

public abstract class BaseRepository
{
    protected ProjectContext Context { get; set; }

    public BaseRepository(ProjectContext context)
    {
        Context = context;
    }
}