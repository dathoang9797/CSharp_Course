using Euro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Euro.Controllers;

public class ClubController : Controller
{
    private ClubRepository ClubRepository { get; set; }

    public ClubController(ClubRepository clubRepository)
    {
        ClubRepository = clubRepository;
    }

    // GET
    public IActionResult Index()
    {
        return View(ClubRepository.GetClubs());
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Club? obj, IFormFile? file)
    {
        if (file != null && obj != null)
        {
            // var ext = Path.GetExtension(file.FileName);
            // obj.Logo = Util.RandomString(16 - ext.Length) + ext;
            // var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", obj.Logo);
            // using (Stream stream = new FileStream(path, FileMode.Create))
            // {
            //     file.CopyTo(stream);
            // }

            // obj.Logo = file.FileName;

            obj.Logo = UploadFile(file);
            var ret = ClubRepository.Add(obj);
            if (ret > 0)
            {
                return Redirect("/club");
            }
        }

        return View();
    }

    [HttpGet]
    public IActionResult Delete(short id)
    {
        return View(ClubRepository.GetClub(id));
    }

    [HttpPost]
    public IActionResult Delete(string logo, short id)
    {
        var ret = ClubRepository.Delete(id);
        if (ret > 0)
        {
            //Xoa file
            // var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", logo);
            // if (System.IO.File.Exists(path))
            // {
            //     System.IO.File.Delete(path);
            // }
            DeleteFile(logo);
            return Redirect("/club");
        }

        return Redirect("/club/error");
    }

    [HttpGet]
    public IActionResult Edit(short id)
    {
        return View(ClubRepository.GetClub(id));
    }

    [HttpPost]
    public IActionResult Edit(short id, Club? obj, IFormFile? file)
    {
        if (obj != null)
        {
            if (file != null)
            {
                var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                // var oldPath = Path.Combine(root, obj.Logo);
                // if (System.IO.File.Exists(oldPath))
                // {
                //     System.IO.File.Delete(oldPath);
                // }

                // var extension = Path.GetExtension(file.FileName);
                // obj.Logo = Util.RandomString(16 - extension.Length) + extension;
                // using (Stream stream = new FileStream(Path.Combine(root, obj.Logo), FileMode.Create))
                // {
                //     file.CopyTo(stream);
                // }

                DeleteFile(root, obj.Logo);
                obj.Logo = UploadFile(file, root);
            }

            var rsp = ClubRepository.Edit(obj);
            if (rsp > 0)
            {
                return Redirect("/club");
            }
        }

        return View();
    }

    [HttpGet]
    public IActionResult Update(short id)
    {
        return View(ClubRepository.GetClub(id));
    }

    [HttpPost]
    public IActionResult Update(short id, Club obj, string? newLogo)
    {
        if (!string.IsNullOrWhiteSpace(newLogo))
        {
            // var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            // var oldPath = Path.Combine(root, obj.Logo);
            // if (System.IO.File.Exists(oldPath))
            // {
            //     System.IO.File.Delete(oldPath);
            // }
            DeleteFile(obj.Logo);
            obj.Logo = newLogo;
        }

        var rsp = ClubRepository.Edit(obj);
        if (rsp > 0)
        {
            return Redirect("/club");
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Upload(IFormFile? file)
    {
        if (file != null)
        {
            // var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            // var extension = Path.GetExtension(file.FileName);
            // var logo = Util.RandomString(16 - extension.Length) + extension;
            // using (Stream stream = new FileStream(Path.Combine(root, logo), FileMode.Create))
            // {
            //     file.CopyTo(stream);
            // }

            var logo = UploadFile(file);
            return Json(logo);
        }

        return Json(null);
    }

    [HttpPost]
    public IActionResult Index(IFormFile? file)
    {
        if (file != null)
        {
            // var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            // var extension = Path.GetExtension(file.FileName);
            // var logo = Util.RandomString(16 - extension.Length) + extension;
            // using (Stream stream = new FileStream(Path.Combine(root, logo), FileMode.Create))
            // {
            //     file.CopyTo(stream);
            // }
            var logo = UploadFile(file);
            return Json(logo);
        }

        return Json(null);
    }

    [HttpPost]
    public IActionResult UpdateLogo(IFormFile? file, short id)
    {
        if (file != null)
        {
            // var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            // var extension = Path.GetExtension(file.FileName);
            // var logo = Util.RandomString(16 - extension.Length) + extension;
            // using (Stream stream = new FileStream(Path.Combine(root, logo), FileMode.Create))
            // {
            //     file.CopyTo(stream);
            // }
            var obj = ClubRepository.GetClub(id);
            if (obj != null)
            {
                var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                DeleteFile(obj.Logo, root);
                var logo = UploadFile(file, root);
                obj.Logo = logo;
                return Json(ClubRepository.Edit(obj));
            }
        }

        return Json(-1);
    }

    private string UploadFile(IFormFile file)
    {
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        return UploadFile(file, root);
    }

    private string UploadFile(IFormFile file, string root)
    {
        var extension = Path.GetExtension(file.FileName);
        var fileName = Util.RandomString(16 - extension.Length) + extension;
        using (Stream stream = new FileStream(Path.Combine(root, fileName), FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return fileName;
    }

    private bool DeleteFile(string root, string fileName)
    {
        var oldPath = Path.Combine(root, fileName);
        if (System.IO.File.Exists(oldPath))
        {
            System.IO.File.Delete(oldPath);
            return true;
        }

        return false;
    }

    private bool DeleteFile(string fileName)
    {
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        return DeleteFile(root, fileName);
    }
}