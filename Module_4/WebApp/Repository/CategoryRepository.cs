using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApp.Models;

namespace WebApp.Repository;

public class CategoryRepository
{
    private Uri BaseUri { get; set; }

    public CategoryRepository(IConfiguration configuration)
    {
        BaseUri = new Uri(configuration["ApiUrl"] ?? string.Empty);
    }

    public async Task<IEnumerable<Category>?> GetCategories()
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        return await client.GetFromJsonAsync<IEnumerable<Category>>("category");
    }

    public async Task<int> Add(Category obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var message = await client.PostAsJsonAsync("category", obj);
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }
    
    public async Task<int> Delete(int id)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var message = await client.DeleteAsync($"category/{id}");
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }
}