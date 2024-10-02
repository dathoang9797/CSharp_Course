using System.ComponentModel.DataAnnotations.Schema;

namespace WebKoi.Models;

[Table("Invoice")]
public class Invoice
{
    public int InvoiceId { get; set; }
    public string? MemberId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public short StatusId { get; set; }
}