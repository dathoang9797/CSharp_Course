using WebAppFruitable.Model;
using WebAppFruitable.VnPayment;

namespace WebAppFruitable.Repository;

public class VnPaymentRepository : BaseRepository
{
    public VnPaymentRepository(FruitableContext context) : base(context)
    {
    }

    public int Add(VnPaymentResponse obj)
    {
        Context.VnPaymentResponses.Add(obj);
        return Context.SaveChanges();
    }
}