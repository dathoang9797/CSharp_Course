using WebKoi.Model;
using WebKoi.Models;

namespace WebKoi.Repository;

public class InvoiceRepository : BaseRepository
{
    public InvoiceRepository(KoiContext context) : base(context)
    {
    }

    public List<Invoice> GetInvoices()
    {
        return Context.Invoice.ToList();
    }

    public Invoice? GetInvoice(int id)
    {
        return Context.Invoice.Find(id);
    }
}