using System.Diagnostics;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers;

public class AuthController : BaseController
// public class AuthController : Controller
{
    private CategoryRepository _categoryRepository;
    // private StoreContext _storeContext;
    //
    // public AuthController(
    //     CategoryRepository categoryRepository,
    //     StoreContext storeContext
    // )
    // {
        // _categoryRepository = categoryRepository;
        // _storeContext = storeContext;
    // }

    // private static CategoryRepository _categoryRepository = new CategoryRepository();

    // public AuthController(StoreContext context) : base(context)
    // {
    // }
    
    public IActionResult Login()
    {
        Provider.Category.DoSomeThing();
        // _categoryRepository.DoSomeThing();
        Console.WriteLine("Login");
        Console.WriteLine("===================");
        return View();
    }

 
}