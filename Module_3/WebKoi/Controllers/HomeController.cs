using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebKoi.Model;

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

    public void LoadData()
    {
        ViewBag.Services = Provider.Service.GetService();
        ViewBag.Roles = Provider.Role.GetRoles();
        ViewBag.NumberOfOrder = new SelectList(Provider.NumberofOrder.GetNumberOfOrder(), "Id", "Name");
        ViewBag.Businesses = new SelectList(Provider.Business.GetBusiness(), "Id", "Name");
    }

    public IActionResult Contact()
    {
        LoadData();
        return View();
    }

    [HttpPost]
    public IActionResult Contact(Customer obj)
    {
        if (ModelState.IsValid)
        {
            var ret = Provider.Customer.Add(obj);
            if (ret > 0)
            {
                TempData["Msg"] = "You Contact Success";
                return Redirect("/home/success");
            }

            ModelState.AddModelError("Error", "Inser Failed");
        }

        LoadData();
        return View(obj);
    }
}