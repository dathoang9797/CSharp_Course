using WebAppFruitable.Model;

namespace WebAppFruitable.Repository;

public class InvoiceRepository : BaseRepository
{
    public InvoiceRepository(FruitableContext context) : base(context)
    {
    }

    public List<Invoice> GetInvoices()
    {
        return Context.Invoice.ToList();
    }

    public List<Invoice>? GetInvoice(string id)
    {
        return Context.Invoice.Where(p => p.MemberId == id).ToList();
    }

    public int Add(Invoice? product)
    {
        if (product != null)
        {
            Context.Invoice.Add(product);
            return Context.SaveChanges();
        }

        return -1;
    }
}