using System.Data;
using System.Net.Http.Headers;
using WebApi.Model;
using WebApp.Models;

namespace WebApp.Repository;

public class MemberRepository : BaseRepository
{
    public MemberRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
    {
    }

    public async Task<int> AddAsync(Member obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.PostAsJsonAsync("member/register", obj);
        if (rsp.IsSuccessStatusCode)

        {
            return await rsp.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }

    public async Task<string?> Login(LoginModel obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.PostAsJsonAsync("member/login", obj);
        if (rsp.IsSuccessStatusCode)

        {
            return await rsp.Content.ReadAsStringAsync();
        }

        return null;
    }

    public async Task<Member?> GetMember(string token)
    {
        try
        {
            // token = string.Empty;
            using var client = new HttpClient();
            client.BaseAddress = BaseUri;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await client.GetFromJsonAsync<Member>("member");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}