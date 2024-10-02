using System.Security.Cryptography;
using System.Text;

namespace WebKoi.Services;

public static class Helper
{
    public static string RandomString(int len)
    {
        var pattern = "qwertyuiopasdfghjklzxcvbnm17890";
        var arr = new char[len];

        var random = new Random();
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = pattern[random.Next(pattern.Length)];
        }

        return string.Join("", arr);
    }

    public static string Upload(IFormFile file, string folder)
    {
        var extension = Path.GetExtension(file.FileName);
        var fileName = Helper.RandomString(32 - extension.Length) + extension;
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder, fileName);
        using Stream stream = new FileStream(path, FileMode.Create);
        file.CopyTo(stream);

        return fileName;
    }

    public static byte[] Hash(string plainText)
    {
        var algorith = SHA512.Create();
        return algorith.ComputeHash(Encoding.ASCII.GetBytes(plainText));
    }
}