using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;

namespace WebAppFruitables.Services;

public static class Helper
{
    public static async Task SignIn(HttpContext httpContext, List<Claim> claims)
    {
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        await httpContext.SignInAsync(new ClaimsPrincipal(identity), new AuthenticationProperties()
        {
            IsPersistent = false
        });
    }

    public static string GenerateToken(IEnumerable<Claim> claims, string secretKey)
    {
        var handler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var token = new JwtSecurityToken(
            issuer: "cse.net.vn",
            audience: "cse.net.vn",
            claims: claims,
            signingCredentials: credentials,
            expires: DateTime.Now.AddMinutes(1));
        return handler.WriteToken(token);
    }

    public static string? RefreshToken(string accessToken, string secretKey)
    {
        var handler = new JwtSecurityTokenHandler();
        var parameters = new TokenValidationParameters
        {
            ValidIssuer = "cse.net.vn",
            ValidAudience = "cse.net.vn",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
            ValidateLifetime = false
        };
        var principal = handler.ValidateToken(accessToken, parameters, out SecurityToken token);
        if (principal != null && token != null && token is JwtSecurityToken jwtSecurity &&
            jwtSecurity.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
        {
            return GenerateToken(principal.Claims, secretKey);
        }

        return null;
    }

    public static byte[] HashPassword(string plainText)
    {
        return SHA512.HashData(Encoding.ASCII.GetBytes(plainText));
    }

    public static async Task<string?> UploadUrl(string url, int len)
    {
        var extension = Path.GetExtension(url);
        var fileName = RandomString(len - extension.Length) + extension;
        var client = new HttpClient();
        var message = await client.GetAsync(url);
        if (!message.IsSuccessStatusCode)
            return null;

        var stream = await message.Content.ReadAsStreamAsync();
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        await using Stream fileStream = new FileStream(Path.Combine(root, "images", fileName), FileMode.Create);
        await stream.CopyToAsync(fileStream);

        return fileName;
    }

    static string RandomString(int len)
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
}