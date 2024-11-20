using System.Data;
using Dapper;
using WebApi.Model;

namespace WebApi.Repository;

public class ProductRepository : BaseRepository
{
    public ProductRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Product> GetProducts(int page = 1, int size = 10)
    {
        var sql = "SELECT * FROM Product ORDER BY ProductId DESC OFFSET @Index ROWS FETCH  NEXT @Size ROWS ONLY;";
        var result = Connection.Query<Product>(sql, new { Index = (page - 1) * size, size });
        return result;
    }

    public Product? GetProduct(int id)
    {
        var sql = "SELECT * FROM Product WHERE  ProductId = @Id;";
        var result = Connection.QuerySingleOrDefault<Product>(sql, new { id });
        return result;
    }

    public string? GetImageUrl(int id)
    {
        var sql = "SELECT ImageUrl FROM Product WHERE ProductId = @id";
        var result = Connection.ExecuteScalar<string>(sql, new { id });
        return result;
    }

    public int Add(Product obj)
    {
        const string query = @"
        INSERT INTO Product 
        (CategoryId, ProductName, Description, Price, Quantity, ImageUrl, CreatedDate, UpdateDate, Viewed)
        VALUES 
        (@CategoryId, @ProductName, @Description, @Price, @Quantity, @ImageUrl, @CreatedDate, @UpdateDate, @Viewed);
    ";

        // Execute the query and return the result
        return Connection.Execute(query, new
        {
            obj.CategoryId,
            obj.ProductName,
            obj.Description,
            obj.Price,
            obj.Quantity,
            obj.ImageUrl,
            obj.CreatedDate,
            obj.UpdateDate,
            obj.Viewed
        });
    }

    public int Edit(Product obj)
    {
        const string query = @"
    UPDATE Product
    SET 
        CategoryId = @CategoryId,
        ProductName = @ProductName,
        Description = @Description,
        Price = @Price,
        Quantity = @Quantity,
        ImageUrl = @ImageUrl,
        UpdateDate = @UpdateDate,
        Viewed = @Viewed
    WHERE ProductId = @ProductId;";

        return Connection.Execute(query, obj);
    }

    public int Count()
    {
        return Connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Product");
    }

    public int Delete(int id)
    {
        return Connection.Execute("DELETE FROM Product WHERE ProductId = @Id", new { id });
    }
}