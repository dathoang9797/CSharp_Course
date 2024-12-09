using WebAppFruitable.Model;

namespace WebAppFruitables.Repository;

public class TestimonialRepository : BaseRepository
{
    public TestimonialRepository(FruitableContext context) : base(context)
    {
    }

    public List<Testimonial> GetTestimonial()
    {
        return Context.Testimonial.ToList();
    }
}