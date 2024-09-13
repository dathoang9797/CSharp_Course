using Microsoft.AspNetCore.Identity;
using WebAppStore.Model;

namespace WebAppVNPayment.Repository;

public class UserRepository
{
    private UserManager<IdentityUser> Manager { get; set; }

    public UserRepository(UserManager<IdentityUser> manager)
    {
        Manager = manager;
    }

    public List<IdentityUser> GetUsers()
    {
        return Manager.Users.ToList();
    }

    public async Task<IdentityResult> Add(RegisterModel obj)
    {
        return await Manager.CreateAsync(new IdentityUser()
        {
            Id = obj.Id,
            UserName = obj.Username,
            Email = obj.Email,
            PhoneNumber = obj.PhoneNumber,
            EmailConfirmed = true
        }, obj.Password);
    }

    public async Task<string?> GenerateEmailConfirmToken(string id)
    {
        var user = await Manager.FindByIdAsync(id);
        if (user != null)
        {
            return await Manager.GenerateEmailConfirmationTokenAsync(user);
        }

        return null;
    }

    public async Task<IdentityResult?> ConfirmEmail(string id, string token)
    {
        var user = await Manager.FindByIdAsync(id);
        if (user != null)
        {
            return await Manager.ConfirmEmailAsync(user, token);
        }

        return null;
    }

    public async Task<IdentityResult?> Change(ChangeModel obj)
    {
        var user = await Manager.FindByIdAsync(obj.UserId);
        if (user != null)
        {
            return await Manager.ChangePasswordAsync(user, obj.OldPassword, obj.NewPassword);
        }

        return null;
    }

    public async Task<Tuple<IdentityUser?, int>> Login(LoginModel obj)
    {
        var status = -1;
        var user = await Manager.FindByNameAsync(obj.Username);
        if (user != null)
        {
            var isPasswordValid = await Manager.CheckPasswordAsync(user, obj.Password);
            status = isPasswordValid ? 1 : 0;
        }

        return new Tuple<IdentityUser?, int>(user, status);
    }

    public async Task<IdentityResult?> Delete(string id)
    {
        var user = await Manager.FindByIdAsync(id);
        if (user != null)
        {
            return await Manager.DeleteAsync(user);
        }

        return null;
    }
}