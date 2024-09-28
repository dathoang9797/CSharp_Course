using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebKoi.Model;

namespace WebKoi.Repository;

public class CustomerRepository : BaseRepository
{
    public CustomerRepository(KoiContext context) : base(context)
    {
    }

    public List<Customer> GetCustomers()
    {
        return Context.Customers.ToList();
    }

    public int Add(Customer obj)
    {
        Context.Customers.Add(obj);
        return Context.SaveChanges();
    }
}