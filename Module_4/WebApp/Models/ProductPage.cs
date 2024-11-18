namespace WebApp.Models;

public class ProductPage
{
    public IEnumerable<Product> Data { get; set; }
    public int Pages { get; set; }
}