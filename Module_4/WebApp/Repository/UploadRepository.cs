using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebApp.Models;

namespace WebApp.Repository;

public class UploadRepository : BaseRepository
{
    public UploadRepository(IDbConnection connection, IConfiguration configuration) : base(connection, configuration)
    {
    }

    public IEnumerable<Upload> GetUploads()
    {
        return Connection.Query<Upload>("SELECT * FROM Upload");
    }

    public int Add(Upload? obj)
    {
        const string sql =
            "INSERT INTO Upload(OriginalName, ImageUrl, Type, Size) VALUES (@OriginalName, @ImageUrl, @Type, @Size)";
        return Connection.Execute(sql, new { obj.OriginalName, obj.ImageUrl, obj.Type, obj.Size });
    }

    public long AddMulti(List<Upload?>? files)
    {
        if (files != null)
        {
            const string sql =
                "INSERT INTO Upload(OriginalName, ImageUrl, Type, Size) VALUES (@OriginalName, @ImageUrl, @Type, @Size)";
            return Connection.Execute(sql,
                files.Select(obj => new { obj.OriginalName, obj.ImageUrl, obj.Type, obj.Size }));
        }

        return -1;
    }

    public async Task<string?> Add(IFormFile file)
    {
        var client = new HttpClient();
        client.BaseAddress = BaseUri;
        var content = new MultipartFormDataContent();
        var streamContent = new StreamContent(file.OpenReadStream());
        content.Add(streamContent, "file", file.FileName);
        var message = await client.PostAsync("upload", content);
        if (message.IsSuccessStatusCode)
        {
            return await message.Content.ReadAsStringAsync();
        }

        return null;
    }
}