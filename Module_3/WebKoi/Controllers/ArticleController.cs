using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebKoi.Model;
using WebKoi.Services;

namespace WebKoi;

[Authorize]
public class ArticleController : BaseController
{
    public ArticleController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    public IActionResult Index()
    {
        return View(Provider.Article.GetArticles());
    }

    public IActionResult Detail(int id)
    {
        return View(Provider.Article.GetArticle(id));
    }

    public IActionResult Edit(int id)
    {
        return View(Provider.Article.GetArticle(id));
    }

    [HttpPost]
    public IActionResult Edit(int id, Article obj, IFormFile? file)
    {
        ModelState.Remove(nameof(obj.MemberId));
        if (!ModelState.IsValid)
        {
            return View(obj);
        }

        if (file != null)
        {
            obj.ImageUrl = Helper.Upload(file, "img");
        }

        obj.ArticleId = id;
        obj.ArticleDate = DateTime.UtcNow;
        obj.MemberId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var ret = Provider.Article.Edit(obj);
        if (ret > 0)
            return Redirect("/article");

        return View(obj);
    }

    public IActionResult Add()
    {
        Console.WriteLine(User.Identity?.Name);
        Console.WriteLine(User.FindFirstValue((ClaimTypes.NameIdentifier)));
        return View();
    }

    [HttpPost]
    public IActionResult Add(Article obj, IFormFile? file)
    {
        ModelState.Remove(nameof(obj.ImageUrl));
        ModelState.Remove(nameof(obj.ArticleDate));
        ModelState.Remove(nameof(obj.MemberId));
        obj.ArticleDate = DateTime.UtcNow;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = Helper.RandomString(32 - extension.Length) + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);
            obj.ImageUrl = fileName;
            using Stream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);

            obj.MemberId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                var ret = Provider.Article.Add(obj);
                if (ret > 0)
                    return Redirect("/article");

                ModelState.AddModelError("Error", "Insert Faild");
            }
        }


        return View(obj);
    }
}