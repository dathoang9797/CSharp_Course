using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL;

public class ProcessingRepository
{
    private string connectionString;
    public ProcessingRepository(string connectionString) => this.connectionString = connectionString;

    public async Task<int> AddAsync()
    {
        var listProduct = new List<Product>();
        var listManuFacture = new List<Manufacturer>();
        var listCategory = new List<Category>();
        var listProductType = new List<ProductType>();
        var listProductCategory = new List<ProductCategory>();

        var countCategory = 0;
        var countManufacture = 0;
        var countProductType = 0;

        var dictCategory = new Dictionary<string, int>();
        var dictProductType = new Dictionary<string, int>();
        var dictManufacture = new Dictionary<string, int>();
        var repository = new DataRepository();
        var list = await repository.GetDataAsync();
        if (list != null)
        {
            foreach (var item in list)
            {
                var product = new Product
                {
                    ProductId = item.ObjectID,
                    ProductName = item.Name,
                    BestSellingRank = item.BestSellingRank,
                    CustomerReviewCount = item.CustomerReviewCount,
                    Image = Path.GetFileName(item.Image),
                    Shipping = item.Shipping,
                    SalePrice = item.SalePrice,
                    SalePriceRange = item.SalePriceRange,
                    ShortDescription = item.ShortDescription,
                    ThumbnailImage = Path.GetFileName(item.ThumbnailImage)
                };

                listProduct.Add(product);
                if (item.Manufacturer != null)
                {
                    if (!dictManufacture.ContainsKey(item.Manufacturer))
                    {
                        dictManufacture[item.Manufacturer] = countManufacture++;
                        var manufacturer = new Manufacturer
                        {
                            ManufacturerId = dictManufacture[item.Manufacturer],
                            ManufacturerName = item.Manufacturer
                        };
                        listManuFacture.Add(manufacturer);

                        product.ManufacturerId = dictManufacture[item.Manufacturer];
                    }
                }

                if (item.Type != null)
                {
                    if (!dictProductType.ContainsKey(item.Type))
                    {
                        dictProductType[item.Type] = countProductType++;
                        var productType = new ProductType
                        {
                            ProductTypeId = dictProductType[item.Type],
                            ProductTypeName = item.Type
                        };
                        listProductType.Add(productType);

                        product.ProductTypeId = dictProductType[item.Type];
                    }
                }

                if (item.Categories.Count != 0)
                {
                    foreach (var cat in item.Categories)
                    {
                        if (cat == null)
                            continue;

                        if (!dictCategory.ContainsKey(cat))
                        {
                            dictCategory[cat] = countCategory++;
                            var category = new Category
                            {
                                CategoryId = dictCategory[cat],
                                CategoryName = cat
                            };
                            listCategory.Add(category);

                            var productCategory = new ProductCategory
                            {
                                ProductId = product.ProductId,
                                CategoryId = dictCategory[cat]
                            };
                            listProductCategory.Add(productCategory);
                        }
                    }
                }
            }
        }

        var ret = 0;
        await using var connection = new SqlConnection(connectionString);
        // const string sql1 = "INSERT INTO Manufacturer (ManufacturerId, ManufacturerName) VALUES (@ManufacturerId, @ManufacturerName)";
        // ret += await connection.ExecuteAsync(sql1, listManuFacture);

        // const string sql2 = "INSERT INTO ProductType (ProductTypeId, ProductTypeName) VALUES (@ProductTypeId, @ProductTypeName)";
        // ret += await connection.ExecuteAsync(sql2, listProductType);

        // const string sql3 = "INSERT INTO Category (CategoryId, CategoryName) VALUES (@CategoryId, @CategoryName)";
        // ret += await connection.ExecuteAsync(sql3, listCategory);

        // const string sql4 =
        //     "INSERT INTO Product (ProductId, ProductName, ShortDescription, SalePrice, ManufacturerId, ProductTypeId, Image, ThumbnailImage, CustomerReviewCount, BestSellingRank, Shipping, SalePriceRange)" +
        //     " VALUES (@ProductId, @ProductName, @ShortDescription, @SalePrice, @ManufacturerId, @ProductTypeId, @Image, @ThumbnailImage, @CustomerReviewCount, @BestSellingRank, @Shipping, @SalePriceRange)";
        // ret += await connection.ExecuteAsync(sql4, listProduct);

        ret += await connection.ExecuteAsync("AddProduct", listProduct, commandType: CommandType.StoredProcedure);

        // const string sql5 =
        //     "INSERT INTO ProductCategory (CategoryId, ProductId) VALUES (@CategoryId, @ProductId)";
        // ret += await connection.ExecuteAsync(sql5, listProductCategory);

        return ret;
    }
}