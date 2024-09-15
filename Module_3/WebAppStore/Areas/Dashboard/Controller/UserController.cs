using Microsoft.AspNetCore.Mvc;
using WebAppStore.Repository;

namespace WebAppStore.Areas.Dashboard;

[Area("dashboard")]
public class UserController : Controller
{
    private UserRepository _userRepository { get; set; }

    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View(_userRepository.GetUsers());
    }

    public async Task<IActionResult> Delete(string id)
    {
        var result = await _userRepository.Delete(id);
        if (result != null && result.Succeeded)
        {
            return Redirect("/dashboard/user");
        }

        return Redirect("/dashboard/user/error");
    }
}