using System.Net.Http.Json;

namespace DAL;

public class DataRepository
{
    public async Task<List<Data>?> GetDataAsync()
    {
        using var client = new HttpClient();
        const string url = "https://raw.githubusercontent.com/algolia/datasets/refs/heads/master/ecommerce/bestbuy_seo.json";
        return await client.GetFromJsonAsync<List<Data>>(url);
    }
}