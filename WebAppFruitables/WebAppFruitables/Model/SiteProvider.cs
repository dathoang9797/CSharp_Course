using WebAppAuthentication.Model;
using WebAppFruitables.Repository;

namespace WebAppFruitables.Models;

public class SiteProvider
{
    private FruitableContext context;
    public SiteProvider(FruitableContext context) => this.context = context;

    private CategoryRepository category = null!;
    private SlideRepository slide = null!;
    private TestimonialRepository testimonial = null!;

    public CategoryRepository Category => category ??= new CategoryRepository(context);
    public SlideRepository Slide => slide ??= new SlideRepository(context);
    public TestimonialRepository Testimonial => testimonial ??= new TestimonialRepository(context);
}