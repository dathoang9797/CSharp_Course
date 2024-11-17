using Microsoft.AspNetCore.Http;
using WebAppAuthentication.Repository;
using WebAppProduct.Provider;

namespace WebKoi.Models;

public class SiteProvider : BaseProvider
{
    public SiteProvider(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    private MemberRepository member;
    public MemberRepository Member => member ??= new MemberRepository(Context);
    
   
}