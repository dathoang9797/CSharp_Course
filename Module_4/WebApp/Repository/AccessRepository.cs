using System.Data;
using WebApp.Models;

namespace WebApp.Repository;

public class AccessRepository : BaseRepository
{
    public AccessRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
    {
    }

    public async Task<IEnumerable<Access>?> GetAccesses()
    {
        using var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var rsp = await client.GetFromJsonAsync<IEnumerable<Access>>("access");
        return rsp;
    }
}