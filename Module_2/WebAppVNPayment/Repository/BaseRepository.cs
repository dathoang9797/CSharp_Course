using WebAppVNPayment.Models;

namespace Euro.Models;

public abstract class BaseRepository
{
    protected StoreContext Context { get; set; }

    public BaseRepository(StoreContext context)
    {
        Context = context;
    }
}