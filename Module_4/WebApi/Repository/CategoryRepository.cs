using System.Data;
using Dapper;
using WebApi.Model;

namespace WebApi.Repository;

public class CategoryRepository : BaseRepository
{
    public CategoryRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Category> GetCategories()
    {
        return Connection.Query<Category>("SELECT * FROM Category");
    }

    public Category? GetCategory(int id)
    {
        return Connection.QueryFirstOrDefault<Category>("SELECT * FROM Category WHERE CategoryId = @Id", new { id });
    }

    public int Add(Category obj)
    {
        return Connection.Execute("INSERT INTO Category(CategoryName) VALUES (@CategoryName)", obj);
    }

    public int Edit(Category obj)
    {
        return Connection.Execute("UPDATE Category SET CategoryName = @CategoryName WHERE CategoryId = @CategoryId",
            obj);
    }

    public int Delete(int id)
    {
        return Connection.Execute("DELETE Category WHERE CategoryId = @Id",
            new { id });
    }
}