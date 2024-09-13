using Euro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Controllers;

namespace Euro.Controllers;

public class SoccerController : BaseController
{
    private const int Size = 50;

    //Ngầm hiểu id = page
    public IActionResult Index(int id = 1)
    {
        ViewBag.Pages = (Provider.Soccer.GetCount() - 1) / Size + 1;
        return View(Provider.Soccer.GetSoccers(id, Size));
    }

    [Route("/soccer/search/{page?}")]
    public IActionResult Search(string q, int page = 1)
    {
        if (string.IsNullOrWhiteSpace(q) || q.Length < 2)
            return Redirect("/soccer");

        ViewBag.Pages = (Provider.Soccer.GetCountSearch(q) - 1) / 10 + 1;
        return View(Provider.Soccer.SearchSoccers(q, page, 10));
    }

    public IActionResult Import() => View();

    [HttpPost]
    public IActionResult Import(IFormFile file)
    {
        if (file != null)
        {
            var listSoccer = new List<Soccer>();
            using (StreamReader sr = new StreamReader(file.OpenReadStream()))
            {
                var line = sr.ReadLine(); //Bỏ dòng đầu tiên
                if (line != null)
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var arr = line.Split(",");
                            var soccer = new Soccer
                            {
                                Name = arr[0],
                                Position = arr[1],
                                Age = Convert.ToByte(arr[2]),
                                Club = arr[3],
                                Height = Convert.ToInt16(arr[4]),
                                Foot = arr[5],
                                Caps = Convert.ToInt16(arr[6]),
                                Goals = Convert.ToByte(arr[7]),
                                MarketValue = Convert.ToInt64(arr[8]),
                                Country = arr[9]
                            };
                            listSoccer.Add(soccer);
                        }
                    }
                }
            }

            if (Provider.Soccer.Add(listSoccer) > 0)
                return Redirect("/soccer");

            ModelState.AddModelError("Msg", "Insert Failed");
        }

        return View();
    }
}