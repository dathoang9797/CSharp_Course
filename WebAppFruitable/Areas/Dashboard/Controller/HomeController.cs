﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitable.Areas.Dashboard.Controller;

[Area("dashboard")]
public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
}