using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitable.Model;

public class CategoryCount : Category
{
    public int Count { get; set; }
}