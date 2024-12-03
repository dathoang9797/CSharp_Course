using Microsoft.AspNetCore.Mvc;

namespace WebAppFruitables.Controllers;

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        ViewBag.Slides = Provider.Slide.GetSlide();
        ViewBag.Testimonials = Provider.Testimonial.GetTestimonial();
        ViewBag.Categories = Provider.Category.GetCategories();
        return View();
    }

    public IActionResult Shop()
    {
        // ViewBag.Categories = Provider.Category.GetCategories(); 
        ViewBag.Categories = Provider.Category.GetCategoryCounts();
        return View();
    }

    public IActionResult Details() => View();
    public IActionResult Contact() => View();
    public IActionResult Testimonial() => View();
    public IActionResult Error404() => View();
}