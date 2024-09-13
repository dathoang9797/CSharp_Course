using Euro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Controllers;

namespace Euro.Controllers;

public class PlayerController : BaseController
{
    // GET
    public IActionResult Index() => View(Provider.Player.GetPlayers());

    public IActionResult Add()
    {
        ViewBag.Teams = new SelectList(Provider.Team.GetTeams(), "TeamId", "TeamName");
        ViewBag.Clubs = new SelectList(Provider.Club.GetClubs(), "Id", "Name");
        ViewBag.Positions = new SelectList(Provider.Position.GetPositions(), "PositionId", "PositionName");

        return View();
    }

    [HttpPost]
    public IActionResult Add(Player obj, IFormFile? file)
    {
        ModelState.Remove(nameof(obj.Photo));
        if (ModelState.IsValid && file != null)
        {
            var ext = Path.GetExtension(file.FileName);
            var photo = Util.RandomString(32 - ext.Length) + ext;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", photo);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            obj.Photo = photo;
            var ret = Provider.Player.Add(obj);
            if (ret > 0)
                return Redirect("/player");

            ModelState.AddModelError("Error", "Insert Failed");
        }

        return View(obj);
    }

    public IActionResult Edit(int id)
    {
        var obj = Provider.Player.GetPlayer(id);
        if (obj != null)
        {
            ViewBag.Teams = new SelectList(Provider.Team.GetTeams(), "TeamId", "TeamName", obj.TeamId);
            ViewBag.Clubs = new SelectList(Provider.Club.GetClubs(), "Id", "Name", obj.ClubId);
            ViewBag.Positions = new SelectList(Provider.Position.GetPositions(), "PositionId", "PositionName",
                obj.PositionId);
            return View(obj);
        }

        return Redirect("/player");
    }

    [HttpPost]
    public IActionResult Edit(int id, Player obj, IFormFile? file)
    {
        if (ModelState.IsValid)
        {
            obj.PlayerId = id;
            if (file != null)
            {
                var ext = Path.GetExtension(file.FileName);
                var photo = Util.RandomString(32 - ext.Length) + ext;
                var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                using (Stream stream = new FileStream(Path.Combine(root, photo), FileMode.Create))
                    file.CopyTo(stream);

                var path = Path.Combine(root, obj.Photo);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                obj.Photo = photo;
            }

            var ret = Provider.Player.Edit(obj);
            if (ret > 0)
            {
                TempData["Msg"] = "Update Success";
                return Redirect("/player");
            }

            ModelState.AddModelError("Error", "Insert Failed");
        }

        return View(obj);
    }
}