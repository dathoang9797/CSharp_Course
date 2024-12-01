using WebAppAuthentication.Model;
using WebAppFruitables.Repository;

namespace WebAppFruitables.Models;

public class SiteProvider
{
    private readonly FruitableContext context;
    public SiteProvider(FruitableContext context) => this.context = context;

    private CategoryRepository _category = null!;
    private SlideRepository _slide = null!;
    private TestimonialRepository _testimonial = null!;
    private MemberRepository _member = null!;

    public CategoryRepository Category => _category ??= new CategoryRepository(context);
    public SlideRepository Slide => _slide ??= new SlideRepository(context);
    public TestimonialRepository Testimonial => _testimonial ??= new TestimonialRepository(context);
    public MemberRepository Member => _member ??= new MemberRepository(context);
}