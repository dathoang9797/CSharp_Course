using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using WebAppFruitable.Model;

namespace WebAppFruitable.Services;

public static class Helper
{
    public static byte[] HashPassword(string plainText)
    {
        return SHA512.HashData(Encoding.ASCII.GetBytes(plainText));
    }

    private static Upload? Upload(IFormFile? file, string root, string folder = "images", string sub = "", int len = 32)
    {
        if (file == null)
            return null;

        var extension = Path.GetExtension(file.FileName);
        var fileName = RandomString(len - extension.Length) + extension;
        using Stream stream = new FileStream(Path.Combine(root, folder, fileName), FileMode.Create);
        file.CopyTo(stream);

        return new Upload()
        {
            OriginalName = file.FileName,
            ImageUrl = string.IsNullOrWhiteSpace(sub) ? fileName : sub + "/" + fileName,
            Size = file.Length,
            Type = file.ContentType,
        };
    }

    public static Upload? Upload(IFormFile file, string folder = "img", string sub = "", int len = 32)
    {
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        return Upload(file, root, folder, sub, len);
    }

    public static string RandomString(int len)
    {
        const string pattern = "qwertyuiopasdfghjklzxcvbnm17890";
        var arr = new char[len];

        var random = new Random();
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = pattern[random.Next(pattern.Length)];
        }

        return string.Join(string.Empty, arr);
    }

    public static string HmaxSha(string key, string plaintext)
    {
        using HMACSHA512 hmac = new HMACSHA512(Encoding.ASCII.GetBytes(key));
        return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintext)));
    }

    public static string GeneratorToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}