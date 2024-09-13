using Microsoft.AspNetCore.Mvc.Rendering;

public static class Util
{
    public static string RandomString(int len){
        var pattern = "qwertyuiopasdfghjklzxcvbnm17890";
        var arr = new char[len];

        var random = new Random();
        for (var i = 0; i < arr.Length; i++){
            arr[i] = pattern[random.Next(pattern.Length)];
        }

        return string.Join("", arr);
    }

    public static int GetPage(this ViewContext context, string name)
    {
        var obj = context.RouteData.Values[name];
        if (obj != null)
            return Convert.ToInt32(obj);
        return 1;
    }
}