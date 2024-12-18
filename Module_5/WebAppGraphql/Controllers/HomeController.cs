using System.Diagnostics;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebAppGraphql.Models;

namespace WebAppGraphql.Controllers;

public class HomeController : Controller
{
    private IGraphQLClient Client { get; set; }
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IGraphQLClient client)
    {
        Client = client;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var query = new GraphQLRequest
        {
            Query = @"
                query ownersQuery{
                  owners {
                    id
                    name
                    address
                    accounts {
                      id
                      type
                      description
                    }
                  }
                }"
        };
        var response = await Client.SendQueryAsync<CategoryResponse>(query);
        return View(response.Data.Categories);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}