using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebKoi.Model;
using WebKoi.Services;

namespace WebKoi;

public class CustomerController : BaseController
{
    public CustomerController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    public IActionResult Index()
    {
        return View(Provider.Customer.GetCustomers());
    }
}