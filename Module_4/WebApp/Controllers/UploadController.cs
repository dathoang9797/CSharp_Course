using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class UploadController : BaseController
{
    public IActionResult Index()
    {
        return View(Provider.Upload.GetUploads());
    }

    public IActionResult Icon()
    {
        return View();
    }


    public IActionResult Simple()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Simple(IFormFile file)
    {
        var obj = Helper.Upload(file);
        var ret = Provider.Upload.Add(obj);
        if (ret > 0)
            return Redirect("/upload");

        return View(obj);
    }

    public IActionResult Multiple()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Multiple(IFormFile[] files)
    {
        var list = Helper.Uploads(files);
        if (list == null)
            return View();

        var enumerable = list.ToList();
        if (enumerable.Count == 0)
            return View();

        var ret = Provider.Upload.AddMulti(enumerable);
        if (ret > 0)
            return Redirect("/upload");

        return View();
    }

    public IActionResult Folder()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Folder(IFormFile[] files)
    {
        var list = Helper.UploadFolder(files);
        if (list == null)
            return View();

        var enumerable = list.ToList();
        if (enumerable.Count == 0)
            return View();

        var ret = Provider.Upload.AddMulti(enumerable);
        if (ret > 0)
            return Redirect("/upload");

        return View();
    }

    public IActionResult Ajax()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ajax(IFormFile file)
    {
        var obj = Helper.Upload(file);
        var ret = Provider.Upload.Add(obj);
        if (ret > 0)
            return Json(obj);

        return Json(null);
    }

    public IActionResult DragAndDrop()
    {
        return View();
    }

    public IActionResult Clipboard()
    {
        return View();
    }
}