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

    public Category? GetCategory(int id)
    {
        return Connection.QuerySingleOrDefault<Category>("SELECT * FROM Category WHERE CategoryId = @Id", new { id });
    }

    public int Add(Category obj)
    {
        const string sql = "INSERT INTO Category(CategoryId, CategoryName) VALUES (@CategoryId, @CategoryName)";
        return Connection.Execute(sql, obj);
    }
}