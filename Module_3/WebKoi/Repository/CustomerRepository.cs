using System.Collections.Generic;
using System.Linq;
using WebKoi.Model;

namespace WebKoi.Repository;

public class CustomerRepository : BaseRepository
{
    public CustomerRepository(KoiContext context) : base(context)
    {
    }

    public List<Customer> GetCustomers()
    {
        return Context.Customer.ToList();
    }

    public int Add(Customer obj)
    {
        Context.Customer.Add(obj);
        return Context.SaveChanges();
    }
}