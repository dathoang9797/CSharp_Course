using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;

namespace DependencyInjection.Controllers;

public class HomeController : BaseController
// public class HomeController : Controller

{
    //Cach 1
    // private CategoryRepository _categoryRepository = new CategoryRepository();

    //Cach 2
    // private CategoryRepository _categoryRepository;
    // public HomeController()
    // {
    //     _categoryRepository = new CategoryRepository();
    // }

    //Cach 3
     // private CategoryRepository _categoryRepository;
     // private ProductRepository _productRepository;
     // public HomeController(CategoryRepository categoryRepository, ProductRepository productRepository)
     // {
     // // Khuyết điểm của constructor, giải quyết kết hợp field + propertires
     // _categoryRepository = categoryRepository;
     // _productRepository = productRepository;
     // }
    
    // private SiteProvider provider;
    //  public HomeController(StoreContext context)
    //  {
    //      provider = new SiteProvider(context);
    //  }

    // private static CategoryRepository _categoryRepository = new CategoryRepository();

    // public HomeController(StoreContext context) : base(context) { }
    public IActionResult Index()
    {
        //Có cách nào đó, sử dụng thằng nào ,thì mới gọi constructors
        // var ret = _categoryRepository.Add();
        var ret = Provider.Category.Add();
        Console.WriteLine(ret);
        Console.WriteLine("===================");
        return View();
    }

    public IActionResult Privacy()
    {
        // _categoryRepository = null;
        // _productRepository.DoThat();
        Provider.Product.DoThat();
        Console.WriteLine("Privacy");
        Console.WriteLine("===================");
        return View();
    }

    public IActionResult About()
    {
        Console.WriteLine(Provider);
        Console.WriteLine("About");
        Console.WriteLine("===================");
        return View();
    }
}