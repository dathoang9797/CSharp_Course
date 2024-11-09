using System.Data;
using Dapper;

namespace DAL;

public class CategoryRepository : BaseRepository
{
    internal CategoryRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Category> GetCategories()
    {
        return Connection.Query<Category>("SELECT * FROM Category");
    }
}