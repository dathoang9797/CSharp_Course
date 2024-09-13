using Euro.Models;
using WebAppVNPayment.Models;

namespace WebAppVNPayment.Repository;

public class VnPaymentRepository : BaseRepository
{
    public VnPaymentRepository(StoreContext context) : base(context)
    {
    }

    public int Add(VnPaymentResponse obj)
    {
        Context.VnPaymentResponses.Add(obj);
        return Context.SaveChanges();
    }
}