using Microsoft.AspNetCore.Mvc;
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
        try
        {
            using var client = new HttpClient();
            client.BaseAddress = BaseUri;
            return await client.GetFromJsonAsync<ProductPage>($"product/{page}/{size}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
    
    public async Task<Product?> GetProduct(int id)
    {
        try
        {
            using var client = new HttpClient();
            client.BaseAddress = BaseUri;
            return await client.GetFromJsonAsync<Product>($"product/{id}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task<int> Add(Product obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var message = await client.PostAsJsonAsync($"product/add", obj);
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }

    public async Task<int> Delete([FromBody] Image obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var message = await client.PostAsJsonAsync($"product/delete/{obj.Id}", obj);
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }
    
    public async Task<int> Edit([FromBody] Product obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var message = await client.PostAsJsonAsync($"product/edit/{obj.ProductId}", obj);
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }
}