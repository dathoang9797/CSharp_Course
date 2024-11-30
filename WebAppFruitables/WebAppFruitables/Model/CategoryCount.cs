using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitables.Model;

public class CategoryCount : Category
{
    public int Count { get; set; }
}