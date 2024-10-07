using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebKoi.Model;
using WebKoi.Services;

namespace WebKoi;

public class HomeController : BaseController
{
    private Notification Notification;

    public HomeController(IHttpContextAccessor accessor, Notification notification) : base(accessor)
    {
        Notification = notification;
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
    public async Task<IActionResult> Contact(Customer obj)
    {
        if (ModelState.IsValid)
        {
            var ret = Provider.Customer.Add(obj);
            if (ret > 0)
            {
                TempData["Msg"] = "You Contact Success";
                await Notification.SendAsync("Contact Success", obj);
                return Redirect("/home/success");
            }

            ModelState.AddModelError("Error", "Inser Failed");
        }

        LoadData();
        return View(obj);
    }

    [HttpPost]
    public IActionResult Recommend(Recommend obj)
    {
        return Json(Provider.Recommend.Add(obj));
    }
}