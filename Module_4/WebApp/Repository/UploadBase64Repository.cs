using System.Data;
using Dapper;
using WebApp.Models;

namespace WebApp.Repository;

public class UploadBase64Repository : BaseRepository
{
    public UploadBase64Repository(IDbConnection connection, IConfiguration configuration) : base(connection,configuration)
    {
    }

    public IEnumerable<Upload> GetUploads()
    {
        return Connection.Query<Upload>("SELECT * FROM Upload");
    }

    public int Add(UploadBase64? obj)
    {
        const string sql =
            "INSERT INTO UploadImageBase64(Image) VALUES (@Image)";
        return Connection.Execute(sql, obj);
    }
}