using WebAppProduct.Models;

namespace WebAppProduct.Provider;

public abstract class BaseProvider
{
    protected IHttpContextAccessor accessor;
    protected BaseProvider(IHttpContextAccessor accessor) => this.accessor = accessor;

    protected ProjectContext? context;
    protected ProjectContext? Context => context ??= accessor.HttpContext?.RequestServices.GetRequiredService<ProjectContext>();
}