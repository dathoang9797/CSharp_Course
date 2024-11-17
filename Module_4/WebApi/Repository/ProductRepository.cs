using System.Data;
using Dapper;
using WebApi.Model;

namespace WebApi.Repository;

public class ProductRepository : BaseRepository
{
    public ProductRepository(IDbConnection connection) : base(connection)
    {
    }

    public IEnumerable<Category> GetProducts()
    {
        return Connection.Query<Category>("SELECT * FROM Product");
    }

    public IEnumerable<Product> Add(Product obj)
    {
        const string query = @"
        INSERT INTO Product 
        (ProductName, Description, Price, Quantity, ImageUrl, CreatedDate, UpdateDate, Viewed)
        VALUES 
        (@ProductName, @Description, @Price, @Quantity, @ImageUrl, @CreatedDate, @UpdateDate, @Viewed);
    ";

        // Execute the query and return the result
        return Connection.Query<Product>(query, new
        {
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
}