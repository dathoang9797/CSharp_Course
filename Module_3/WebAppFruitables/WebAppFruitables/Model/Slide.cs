using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitables.Model;

[Table("Slide")]
public class Slide
{
    public byte SlideId { get; set; }
    public string SlideName { get; set; }
    public string ImageUrl { get; set; }

}