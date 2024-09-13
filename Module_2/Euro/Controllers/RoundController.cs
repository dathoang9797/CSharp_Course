using Euro.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace Euro.Controllers;

public class RoundController : BaseController
{
    public IActionResult Index()
    {
        return View(Provider.Round.GetRounds());
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Round obj)
    {
        if (ModelState.IsValid)
        {
            int ret = Provider.Round.Add(obj);
            if (ret > 0)
            {
                return Redirect("/round");
            }
        }

        return View(obj);
    }

    public IActionResult Edit(byte id)
    {
        return View(Provider.Round.GetRound(id));
    }

    [HttpPost]
    public IActionResult Edit(byte id, Round obj)
    {
        if (ModelState.IsValid)
        {
            obj.RoundId = id;
            var ret = Provider.Round.Edit(obj);
            if (ret > 0)
            {
                return Redirect("/round");
            }
        }

        return View(obj);
    }

    [HttpPost]
    public IActionResult Delete(byte id)
    {
        var ret = Provider.Round.Delete(id);
        if (ret > 0)
        {
            return Redirect("/round");
        }

        return Redirect("/round/error");
    }
}