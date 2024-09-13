using System.Security.Cryptography;
using System.Text;

namespace WebAppVNPayment;

public static class Helper
{
    public static string HmaxSHA(string key, string plaintext)
    {
        using (HMACSHA512 hmac = new HMACSHA512(Encoding.ASCII.GetBytes(key)))
        {
            return Convert.ToHexString(hmac.ComputeHash(Encoding.UTF8.GetBytes(plaintext)));
        }
    }

    public static string RandomString(int len)
    {
        var stringBuilder = new StringBuilder(len);
        var pattern = "3123213215@dathoang97@gmail.com";
        var random = new Random();
        for (var i = 0; i < len; i++)
        {
            stringBuilder.Append(pattern[random.Next(pattern.Length)]);
        }

        return stringBuilder.ToString();
    }
}