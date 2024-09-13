using Euro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Euro.Controllers;

public class TeamController : Controller
{
    private TeamRepository TeamRepository { get; set; }

    public TeamController(TeamRepository teamRepository)
    {
        TeamRepository = teamRepository;
    }

    // GET
    public IActionResult Index()
    {
        return View(TeamRepository.GetTeams());
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Team obj)
    {
        var rsp = TeamRepository.Add(obj);
        if (rsp > 0)
        {
            return Redirect("/team");
        }

        return View(obj);
    }

    public IActionResult Delete(short id)
    {
        int rsp = TeamRepository.Delete(id);
        if (rsp > 0)
        {
            return Redirect("/team");
        }

        return Redirect("/team/error");
    }

    [HttpGet]
    public IActionResult Edit(short id)
    {
        return View(TeamRepository.GetTeam(id));
    }

    [HttpPost]
    public IActionResult Edit(short id, Team obj)
    {
        obj.TeamId = id;
        var rsp = TeamRepository.Edit(obj);
        if (rsp > 0)
        {
            return Redirect("/team");
        }

        return View(obj);
    }
}