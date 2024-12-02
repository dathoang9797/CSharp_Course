using Microsoft.AspNetCore.Mvc;
using WebAppFruitables.Model;

namespace WebAppFruitables.Areas.Dashboard.Controller;

[Area("dashboard")]
public class ProductController : BaseController
{
    public IActionResult Index()
    {
        var listProduct = Provider.Product.GetProducts();
        ViewBag.Categories = Provider.Category.GetCategories();
        return View(listProduct);
    }
    
    [HttpPost]
    public IActionResult Create(ProductForm obj, IFormFile File)
    {
        return Redirect("/dashboard/product");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var ret = Provider.Product.Delete(id);
        if (ret > -1)
        {
            TempData["Msg"] = "Deleted successfully!";
        }
        else
        {
            TempData["Msg"] = "Delete not successful.";
        }

        return Redirect("/dashboard/product");
    }
}