using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebKoi.Model;

public abstract class BaseProvider
{
    protected IHttpContextAccessor accessor;
    protected BaseProvider(IHttpContextAccessor accessor) => this.accessor = accessor;

    protected KoiContext? context;
    protected KoiContext? Context => context ??= accessor.HttpContext?.RequestServices.GetRequiredService<KoiContext>();
}