using Microsoft.AspNetCore.Mvc;
using WebAppVNPayment.Models;

namespace WebAppVNPayment.Controller;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        ViewBag.Categories = Provider.Category.GetListCategories();
        return View(Provider.Products.GetListProduct());
    }
}