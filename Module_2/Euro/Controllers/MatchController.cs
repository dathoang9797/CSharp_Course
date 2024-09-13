using Euro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Controllers;

namespace Euro.Controllers;

public class MatchController : BaseController
{
    // GET
    public IActionResult Index() => View(Provider.Match.GetMatch());

    public IActionResult Add()
    {
        var teams = Provider.Team.GetTeams();
        var rounds = Provider.Round.GetRounds();
        ViewBag.Teams = new SelectList(teams, "TeamId", "TeamName");
        ViewBag.Rounds = new SelectList(rounds, "RoundId", "RoundName");
        return View();
    }

    [HttpPost]
    public IActionResult Add(Match obj)
    {
        var ret = Provider.Match.Add(obj);
        if (ret > 0)
        {
            TempData["Msg"] = "Inserted Success";
            return Redirect("/match");
        }

        return Add();
    }

    public IActionResult Edit(short id)
    {
        var obj = Provider.Match.GetMatch(id);
        if (obj != null)
        {
            var teams = Provider.Team.GetTeams();
            var rounds = Provider.Round.GetRounds();
            ViewBag.Teams1 = new SelectList(teams, "TeamId", "TeamName", obj.TeamId1);
            ViewBag.Teams2 = new SelectList(teams, "TeamId", "TeamName", obj.TeamId2);
            ViewBag.Rounds = new SelectList(rounds, "RoundId", "RoundName", obj.RoundId);
            return View(obj);
        }

        return Redirect("/match");
    }

    [HttpPost]
    public IActionResult Edit(short id, Match obj)
    {
        obj.MatchId = id;
        var ret = Provider.Match.Edit(obj);
        if (ret > 0)
        {
            TempData["Msg"] = "Update Success";
            return Redirect("/match");
        }

        return Add();
    }
}