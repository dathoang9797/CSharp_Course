using WebAppFruitable.Model;

namespace WebAppFruitables.Repository;

public abstract class BaseRepository
{
    protected FruitableContext Context { get; set; }

    public BaseRepository(FruitableContext context)
    {
        Context = context;
    }
}