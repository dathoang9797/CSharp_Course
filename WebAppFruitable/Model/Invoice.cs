using System.Collections;

namespace WebAppFruitable.Model;

public class Invoice : IEnumerable
{
    public long InvoiceId { get; set; }
    public decimal Amount { get; set; }
    public string Mobile { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public virtual string? MemberId { get; set; }
    public string PaymentMethod { get; set; } = null!;
    public DateTime InvoiceDate { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}