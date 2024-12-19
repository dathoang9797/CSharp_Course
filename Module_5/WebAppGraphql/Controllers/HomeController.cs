using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebAppGraphql.Models;

namespace WebAppGraphql.Controllers;

public class HomeController : Controller
{
    private IGraphQLClient Client { get; set; }
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        ILogger<HomeController> logger,
        IGraphQLClient client
    )
    {
        Client = client;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var query = new GraphQLRequest
        {
            Query = @"{
             categories{
                        id,
                         name
                }
            }"
        };
        var response = await Client.SendQueryAsync<CategoriesResponse>(query);
        return View(response.Data.Categories);
    }

    public async Task<IActionResult> Details(int id)
    {
        var query = new GraphQLRequest
        {
            Query = @"
        query($id: Int!){
            category(id: $id){
                id
                name
            }
        }",
            Variables = new { id }
        };

        var response = await Client.SendQueryAsync<CategoryResponse>(query);

        if (response.Errors != null && response.Errors.Any())
        {
            return BadRequest(response.Errors);
        }

        return View(response.Data.Category);
    }
}