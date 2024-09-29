using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebKoi;

public class HomeController : BaseController
{
    public HomeController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        ViewBag.Services = Provider.Service.GetService();
        ViewBag.Roles = Provider.Role.GetRoles();
        ViewBag.NumberOfOrder = new SelectList(Provider.NumberofOrder.GetNumberOfOrder(), "Id", "Name");
        ViewBag.Businesses = new SelectList(Provider.Business.GetBusiness(), "Id", "Name");
        return View();
    }
}