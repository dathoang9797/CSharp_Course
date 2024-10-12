using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebKoi.Model;

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
        return Context.Invoice.Include(p => p.InvoiceDetails).FirstOrDefault(q => q.InvoiceId == id);
    }

    public List<Invoice> GetInvoiceByStatus(short id)
    {
        return Context.Invoice.Include(p => p.Status).Where(p => p.StatusId == id).ToList();
    }

    public List<InvoiceTotal> GetInvoiceByMember(string id)
    {
        return Context.Invoice.Include(p => p.Status)
            .Include(p => p.InvoiceDetails)
            .Where(p => p.MemberId == id)
            .Select(p => new InvoiceTotal()
            {
                InvoiceId = p.InvoiceId,
                InvoiceDate = p.InvoiceDate,
                MemberId = p.MemberId,
                Total = p.InvoiceDetails != null
                    ? p.InvoiceDetails.Sum(q => q.Price * q.Quantity)
                    : 0
            })
            .ToList();
    }

    public int UpdateStatus(Invoice obj)
    {
        return Context.Database.ExecuteSqlRaw("UPDATE Invoice SET StatusId = @StatusId WHERE  InvoiceId = @InvoiceId",
        [
            new SqlParameter("@StatusId", obj.StatusId),
            new SqlParameter("@InvoiceId", obj.InvoiceId)
        ]);
    }

    public int UpdateStatus(int[] ids, short statusId)
    {
        return Context.Database.ExecuteSql(
            $"UPDATE Invoice SET StatusId ={statusId} WHERE InvoiceId IN ({string.Join(",", ids)})");
    }
}