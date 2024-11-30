using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppFruitables.Model;

[Table("Testimonial")]
public class Testimonial
{
    public int TestimonialId { get; set; }
    public string FullName { get; set; }
    public string Job { get; set; }
    public string Description { get; set; }
    public byte Rating { get; set; }
    public string ImageUrl { get; set; }
}