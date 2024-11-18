using WebApp.Models;

namespace WebApp.Repository;

public class ProductRepository
{
    private Uri BaseUri { get; set; }

    public ProductRepository(IConfiguration configuration)
    {
        BaseUri = new Uri(configuration["ApiUrl"] ?? string.Empty);
    }

    // public async Task<IEnumerable<Product>?> GetProducts()
    // {
    //     using var client = new HttpClient();
    //     client.BaseAddress = BaseUri;
    //     return await client.GetFromJsonAsync<IEnumerable<Product>>("product");
    // }

    public async Task<ProductPage?> GetProducts(int page = 1, int size = 5)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        return await client.GetFromJsonAsync<ProductPage>($"product/{page}/{size}");
    }

    public async Task<Product?> GetProduct(int id)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        return await client.GetFromJsonAsync<Product>($"product/{id}");
    }


    public async Task<int> Add(Product obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var message = await client.PostAsJsonAsync($"product", obj);
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }
}