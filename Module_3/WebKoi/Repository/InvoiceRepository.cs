using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        return Context.Invoice.Include(p => p.Status).ToList();
    }

    public Invoice? GetInvoice(int id)
    {
        return Context.Invoice.Find(id);
    }

    public int UpdateStatus(Invoice obj)
    {
        return Context.Database.ExecuteSqlRaw("UPDATE Invoice SET StatusId = @StatusId WHERE  InvoiceId = @InvoiceId",
        [
            new SqlParameter("@StatusId", obj.StatusId),
            new SqlParameter("@InvoiceId", obj.InvoiceId)
        ]);
    }
}