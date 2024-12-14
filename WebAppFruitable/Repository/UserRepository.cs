using System.Net;
using Microsoft.AspNetCore.Identity;
using WebAppFruitable.Model;

namespace WebAppFruitable.Repository;

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

    public async Task<IdentityResult> Add(Register obj)
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

    public async Task<int> Add(IdentityUser user)
    {
        var obj = await Manager.FindByIdAsync(user.Id);
        if (obj is null)
        {
            var result = await Manager.CreateAsync(user);
            if (result.Succeeded)
                return 1;

            return 0;
        }

        return 1;
    }

    public async Task<string?> GenerateTwoFactorTokenAsync(IdentityUser user, string provider)
    {
        return await Manager.GenerateTwoFactorTokenAsync(user, provider);
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

    public async Task<IdentityResult?> Change(Change obj)
    {
        var user = await Manager.FindByIdAsync(obj.UserId);
        if (user != null)
        {
            if (obj.OldPassword != null)
                if (obj.NewPassword != null)
                    return await Manager.ChangePasswordAsync(user, obj.OldPassword, obj.NewPassword);
        }

        return null;
    }

    public async Task<Tuple<IdentityUser?, int>> Login(Login obj)
    {
        var status = -1;
        if (obj.Username != null)
        {
            var user = await Manager.FindByNameAsync(obj.Username);
            if (user != null)
            {
                var isPasswordValid = obj.Password != null && await Manager.CheckPasswordAsync(user, obj.Password);
                status = isPasswordValid ? 1 : 0;
            }

            return new Tuple<IdentityUser?, int>(user, status);
        }

        return new Tuple<IdentityUser?, int>(null, status);
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

    //Tạo ra token từ email
    public async Task<ResetPassword?> GeneratePasswordResetToken(string email)
    {
        var user = await Manager.FindByEmailAsync(email);
        if (user != null)
        {
            return new ResetPassword()
            {
                Id = user.Id,
                Token = WebUtility.UrlEncode(await Manager.GeneratePasswordResetTokenAsync(user))
            };
        }

        return null;
    }

    public async Task<IdentityResult?> ResetPassword(ResetPassword obj)
    {
        if (obj.Id != null)
        {
            var user = await Manager.FindByIdAsync(obj.Id);
            if (user != null)
            {
                if (obj.Password != null)
                    return await Manager.ResetPasswordAsync(user, WebUtility.UrlDecode(obj.Token) ?? string.Empty,
                        obj.Password);
            }
        }

        return null;
    }
}