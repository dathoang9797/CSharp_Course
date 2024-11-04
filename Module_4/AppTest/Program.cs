using System;
using DAL;

var repository = new ProductRepository();
var list = await repository.GetProducts();
if (list != null)
{
    foreach (var item in list)
    {
        Console.WriteLine(item.ProductId);
        Console.WriteLine(item.ProductName);
    }
}