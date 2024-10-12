using System.ComponentModel.DataAnnotations.Schema;
using WebKoi.Models;

namespace WebKoi.Model;

[Table("Invoice")]
public class Invoice
{
    public int InvoiceId { get; set; }
    public string? MemberId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public short StatusId { get; set; }
    public Status? Status { get; set; }
    public List<InvoiceDetail>? InvoiceDetails { get; set; }
}