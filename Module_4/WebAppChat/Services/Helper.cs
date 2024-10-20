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
}