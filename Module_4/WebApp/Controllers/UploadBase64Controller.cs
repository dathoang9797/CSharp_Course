using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class UploadBase64Controller : BaseController
{
    public IActionResult Index()
    {
        return View(Provider.Upload.GetUploads());
    }

    public IActionResult Upload(string url)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Upload(IFormFile? file)
    {
        if (file != null)
        {
            //stream => bytes[]
            using var ms = new MemoryStream();
            file.CopyTo(ms);
            var img = new UploadBase64()
            {
                Image = ms.ToArray(),
            };
            Provider.Uploadbase64.Add(img);
            return Redirect("/uploadbase64");
        }

        return View();
    }
}