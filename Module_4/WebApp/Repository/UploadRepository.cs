using System.Data;
using Dapper;
using WebApp.Models;

namespace WebApp.Repository;

public class UploadRepository : BaseRepository
{
    public UploadRepository(IDbConnection connection) : base(connection)
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
}