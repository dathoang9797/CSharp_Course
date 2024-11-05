namespace DAL;

public class ProcessingRepository
{
    private string connectionString;
    public ProcessingRepository(string connectionString) => this.connectionString = connectionString;

    public async Task<int> Add()
    {
        var listProduct = new List<Product>();
        var listManuFacture = new List<Manufacture>();
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
                    Image = item.Image,
                    Shipping = item.Shipping,
                    SalePrice = item.SalePrice,
                    SalePriceRange = item.SalePriceRange,
                    ShortDescription = item.ShortDescription,
                    ThumbnailImage = item.ThumbnailImage,
                };

                listProduct.Add(product);
                if (item.Manufacturer != null)
                {
                    if (!dictManufacture.ContainsKey(item.Manufacturer))
                    {
                        dictManufacture[item.Manufacturer] = countManufacture++;
                        var manufacture = new Manufacture
                        {
                            ManufactureId = dictManufacture[item.Manufacturer],
                            ManufactureName = item.Manufacturer
                        };
                        listManuFacture.Add(manufacture);
                    }

                    product.ManufacturerId = dictCategory[item.Manufacturer];
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
                    }

                    product.ProductTypeId = dictCategory[item.Type];
                }

                if (item.Categories.Count != 0)
                {
                    foreach (var cat in item.Categories)
                    {
                        if (!dictCategory.ContainsKey(cat))
                        {
                            dictCategory[cat] = countCategory++;
                            var category = new Category
                            {
                                CategoryId = dictCategory[cat],
                                CategoryName = cat
                            };
                            listCategory.Add(category);
                        }

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

        return 0;
    }
}