using System;
using DAL;

var repository = new DataRepository();
var list = await repository.GetDataAsync();
if (list != null)
{
    foreach (var item in list)
    {
        Console.WriteLine(item.ObjectID);
        Console.WriteLine(item.Name);
        Console.WriteLine(item.ShortDescription);
        Console.WriteLine(item.BestSellingRank);
        Console.WriteLine(item.ThumbnailImage);
        Console.WriteLine(item.SalePrice);
        Console.WriteLine(item.Manufacturer);
        Console.WriteLine(item.Type);
        Console.WriteLine(item.Image);
        Console.WriteLine(item.CustomerReviewCount);
        Console.WriteLine(item.Shipping);
        Console.WriteLine(item.SalePriceRange);
    }
}