namespace Euro.Models;

public abstract class BaseRepository
{
    protected EuroContext Context { get; set; }

    public BaseRepository(EuroContext context)
    {
        Context = context;
    }
}