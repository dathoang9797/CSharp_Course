using System.Collections.Generic;
using System.Linq;
using WebKoi.Model;

namespace WebKoi.Repository;

public class NumberOfOrderRepository : BaseRepository
{
    public NumberOfOrderRepository(KoiContext context) : base(context)
    {
    }

    public List<NumberOfOrder> GetNumberOfOrder()
    {
        return Context.NumberOfOrders.ToList();
    }
}