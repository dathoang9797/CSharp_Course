using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppFruitable.Model;
using WebAppFruitable.Services;
using WebAppFruitable.VnPayment;
using WebAppFruitables;

namespace WebAppFruitable.Controllers;

public class DetailController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}