using WebAppAuthentication.Model;
using WebAppFruitables.Repository;

namespace WebApplication1.Models;

public class SiteProvider
{
    private FruitableContext context;
    public SiteProvider(FruitableContext context) => this.context = context;

    private CategoryRepository category = null!;
    private SlideRepository slide = null!;

    public CategoryRepository Category => category ??= new CategoryRepository(context);
    public SlideRepository Slide => slide ??= new SlideRepository(context);

}