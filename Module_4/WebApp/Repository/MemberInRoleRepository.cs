using System.Data;
using System.Net.Http.Headers;
using WebApi.Model;
using WebApp.Models;

namespace WebApp.Repository;

public class MemberInRoleRepository : BaseRepository
{
    public MemberInRoleRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
    {
    }

    public async Task<int> AddAsync(MemberInRole obj)
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.PostAsJsonAsync("memberinrole", obj);
        if (rsp.IsSuccessStatusCode)

        { 
            return await rsp.Content.ReadFromJsonAsync<int>();
        }

        return -1;
    }
}