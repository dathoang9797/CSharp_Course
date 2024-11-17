using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.Services;

namespace WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class UploadController : BaseController
{
    [HttpPost]
    public string Post(IFormFile file)
    {
        var result = Helper.Upload(file);
        return result?.ImageUrl ?? string.Empty;
    }

    
}