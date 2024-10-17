using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class UploadController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Simple()
    {
        return View();
    }

    public IActionResult Multiple()
    {
        return View();
    }

    public IActionResult Ajax()
    {
        return View();
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