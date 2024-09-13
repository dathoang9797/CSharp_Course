namespace WebAppVNPayment.Models;

public class Invoice
{
    public long InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Mobile { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
}