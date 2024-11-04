using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers;

public class UploadController : BaseController
{
    public IActionResult Index()
    {
        return View(Provider.Upload.GetUploads());
    }

    [HttpPost] 
    public async Task<IActionResult> UploadUrl(string url)
    {
        var fileName = await Helper.UploadUrl(url, 32);
        return View(model: fileName);
    }

    public IActionResult UploadUrl()
    {
        return View();
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

    public IActionResult AjaxMultiple()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AjaxMultiple(IFormFile[] files)
    {
        var list = Helper.UploadFolder(files);
        if (list == null)
            return View();

        var enumerable = list.ToList();
        if (enumerable.Count == 0)
            return View();

        var ret = Provider.Upload.AddMulti(enumerable);
        if (ret > 0)
            return Json(enumerable);

        return Json(null);
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