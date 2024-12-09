using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebAppFruitable.Model;
using WebAppFruitable.Services;
using WebAppFruitables;
using WebAppFruitables.Services;

namespace WebAppFruitable.Areas.Dashboard.Controller;

[Area("dashboard")]
public class CategoryController : BaseController
{
    [Authorize]
    public IActionResult Index()
    {
        var listProduct = Provider.Product.GetProducts();
        ViewBag.Categories = Provider.Category.GetCategories();
        return View(listProduct);
    }

    [HttpPost]
    public IActionResult Create(ProductForm? obj, IFormFile? file)
    {
        if (obj == null)
            return Redirect("/dashboard/product");

        Upload? fileUpload = null;
        if (file != null)
            fileUpload = Helper.Upload(file);

        var productNew = new Product()
        {
            ProductName = obj.ProductName,
            ImageUrl = fileUpload?.ImageUrl ?? string.Empty,
            CategoryId = obj.CategoryId,
            Rating = obj.Rating,
            Price = obj.Price,
            Description = obj.Description,
        };

        var ret = Provider.Product.Add(productNew);
        if (ret > -1)
        {
            TempData["Msg"] = "Create successfully!";
        }
        else
        {
            TempData["Msg"] = "Create not successful.";
        }

        return Redirect("/dashboard/product");
    }

    [HttpGet]
    [Route("/dashboard/product/update/{id}")]
    public IActionResult Update([FromRoute] int id)
    {
        var product = Provider.Product.GetProduct(id);
        return Json(product);
    }

    [HttpPost]
    public IActionResult Update(ProductFormEdit? obj, IFormFile? file)
    {
        if (obj?.ProductId == null)
        {
            TempData["Msg"] = "Param not valid!";
            return Redirect("/dashboard/product");
        }
          

        Upload? fileUpload = null;
        if (file != null)
        {
            fileUpload = Helper.Upload(file);
            var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","img");
            var path = Path.Combine(root, obj.ImageUrl);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        var productUpdate = new Product()
        {
            ProductId = obj.ProductId,
            ProductName = obj.ProductName,
            ImageUrl = fileUpload?.ImageUrl ?? obj.ImageUrl,
            CategoryId = obj.CategoryId,
            Rating = obj.Rating,
            Price = obj.Price,
            Description = obj.Description,
        };

        var ret = Provider.Product.Update(productUpdate);
        if (ret > -1)
        {
            TempData["Msg"] = "Update successfully!";
        }
        else
        {
            TempData["Msg"] = "Update not successful.";
        }

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