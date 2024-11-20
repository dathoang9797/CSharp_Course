using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Controllers;

public class ProductController : BaseController
{
    [HttpGet("product/{action=index}/{page?}")]
    public async Task<IActionResult> Index([FromRoute] int page = 1, [FromRoute] int size = 5)
    {
        var result = await Provider.Product.GetProducts(page, size);
        return View(result);
    }

    public async Task<IActionResult> Add()
    {
        var categories = await Provider.Category.GetCategories();
        var selectList = new SelectList(categories, "CategoryId", "CategoryName");
        ViewBag.Categories = selectList;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(Product obj)
    {
        obj.CreatedDate = DateTime.UtcNow;
        obj.UpdateDate = DateTime.UtcNow;
        var result = await Provider.Product.Add(obj);
        if (result > 0)
        {
            TempData["Msg"] = "Insert Success";
            return Redirect("/product");
        }

        return Redirect("/product/error");
    }

    [HttpGet]
    public async Task<IActionResult> Edit([FromRoute] int id)
    {
        var categories = await Provider.Category.GetCategories();
        var selectList = new SelectList(categories, "CategoryId", "CategoryName");
        ViewBag.Categories = selectList;
        var product = await Provider.Product.GetProduct(id);
        if (product == null)
            return Redirect("/product");

        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute] int id, Product obj)
    {
        obj.ProductId = id;
        var ret = await Provider.Product.Edit(obj);
        if (ret > 0)
            return Redirect("/product");

        return await Add();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Image obj)
    {
        var result = await Provider.Product.Delete(obj);
        if (result > 0)
        {
            TempData["Msg"] = "Insert Success";
            return Redirect("/product");
        }

        return Redirect("/product/error");
    }

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var categories = await Provider.Category.GetCategories();
        var selectList = new SelectList(categories, "CategoryId", "CategoryName");
        ViewBag.Categories = selectList;
        return View(await Provider.Product.GetProduct(id));
    }
}