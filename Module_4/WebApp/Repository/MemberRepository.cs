using System.Data;
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
}