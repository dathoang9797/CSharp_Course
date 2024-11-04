namespace DAL;

public class ProductRepository
{
    public async Task<List<Product>?> GetProducts()
    {
        using var client = new HttpClient();
        const string url = "https://raw.githubusercontent.com/algolia/datasets/refs/heads/master/ecommerce/bestbuy_seo.json";
        return await client.GetFromJsonAsync<List<Product>>(url);
    }
}