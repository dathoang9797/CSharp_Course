using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;
using WebAppFruitables;

namespace WebAppFruitable.Areas.Dashboard.Controller;

[Area("dashboard")]
public class CategoryController : BaseController
{
    [Authorize]
    public IActionResult Index()
    {
        var listCategory = Provider.Category.GetCategories();
        return View(listCategory);
    }

    [HttpPost]
    public IActionResult Create(CategoryForm? obj)
    {
        if (obj == null || string.IsNullOrWhiteSpace(obj.CategoryName))
            return Redirect("/dashboard/category");

        var category = new Category()
        {
            CategoryName = obj.CategoryName,
        };

        category.CategoryId = Convert.ToByte(category.CategoryId);
        var ret = Provider.Category.Add(category);
        if (ret > -1)
        {
            TempData["Msg"] = "Create successfully!";
        }
        else
        {
            TempData["Msg"] = "Create not successful.";
        }

        return Redirect("/dashboard/category");
    }

    [HttpGet]
    [Route("/dashboard/category/update/{id}")]
    public IActionResult Update([FromRoute] byte id)
    {
        var category = Provider.Category.GetCategory(id);
        return Json(category);
    }

    [HttpPost]
    public IActionResult Update(CategoryUpdate? obj)
    {
        if (obj?.CategoryName == null)
        {
            TempData["Msg"] = "Param not valid!";
            return Redirect("/dashboard/category");
        }

        var categoryId = Convert.ToByte(obj.CategoryId);
        var categoryUpdate = new Category()
        {
            CategoryId = categoryId,
            CategoryName = obj.CategoryName
        };

        var ret = Provider.Category.Update(categoryUpdate);
        if (ret > -1)
        {
            TempData["Msg"] = "Update successfully!";
        }
        else
        {
            TempData["Msg"] = "Update not successful.";
        }

        return Redirect("/dashboard/category");
    }

    [HttpPost]
    public IActionResult Delete(CategoryFormDelete? obj)
    {
        try
        {
            if (obj?.CategoryId == null)
                return Redirect("/dashboard/category");

            var categoryId = Convert.ToByte(obj.CategoryId);
            var ret = Provider.Category.Delete(categoryId);
            if (ret > -1)
            {
                TempData["Msg"] = "Deleted successfully!";
            }
            else
            {
                TempData["Msg"] = "Delete not successful.";
            }

            return Redirect("/dashboard/category");
        }
        catch (Exception e)
        {
            TempData["Msg"] = "Delete not successful.";
            return Redirect("/dashboard/category");
        }
    }
}