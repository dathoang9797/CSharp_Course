using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CategoryController : BaseController
{
    public async Task<IActionResult> Index()
    {
        var result = await Provider.Category.GetCategories();
        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Category obj)
    {
        var result = await Provider.Category.Add(obj);
        if (result > 0)
        {
            TempData["Msg"] = "Insert Success";
            return Redirect("/category");
        }

        return Redirect("/category/error");
    }
    
    [HttpPost]
    public async Task<IActionResult> Detail(int id)
    {
        return Json(await Provider.Category.GetCategory(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Category obj)
    {
        obj.CategoryId = id;
        var result = await Provider.Category.Edit(obj);
        if (result > 0)
        {
            TempData["Msg"] = "Update Success";
            return Redirect("/category");
        }

        return Redirect("/category/error");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await Provider.Category.Delete(id);
        if (result > 0)
        {
            TempData["Msg"] = "Insert Success";
            return Redirect("/category");
        }

        return Redirect("/category/error");
    }
}