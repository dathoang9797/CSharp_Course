using System.Security.Cryptography;
using System.Text;

namespace WebAppChat.Services;

public static class Helper
{
    public static byte[] Hash(string plainText)
    {
        return SHA512.HashData(Encoding.ASCII.GetBytes(plainText));
    }

    public static string HashString(string plainText)
    {
        return Convert.ToHexString(Hash(plainText));
    }
    
    public static async Task<string?> UploadUrl(string url, int len)
    {
        var extension = Path.GetExtension(url);
        var fileName = RandomString(len - extension.Length) + extension;
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images",fileName);
        await using Stream fileStream = new FileStream(path, FileMode.Create);
        await fileStream.CopyToAsync(fileStream);
        return fileName;
    }

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
}