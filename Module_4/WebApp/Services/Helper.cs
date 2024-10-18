using WebApp.Models;

namespace WebApp.Services;

public static class Helper
{
    static string RandomString(int len)
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

    public static Upload? Upload(IFormFile file, string folder = "images", string sub = "", int len = 32)
    {
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        return Upload(file, root, folder, sub, len);
    }

    public static IEnumerable<Upload?> Uploads(IEnumerable<IFormFile> files, string root, string folder = "images",
        string sub = "", int len = 32)
    {
        return files.Select(file => Upload(file, root, folder, sub, len));
    }

    public static IEnumerable<Upload?> Uploads(IEnumerable<IFormFile> files, string folder = "images", string sub = "",
        int len = 32)
    {
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        return Uploads(files, root, folder, sub, len);
    }

    private static IEnumerable<Upload?> UploadFolder(IEnumerable<IFormFile> files, string root, string folder = "images",
        int len = 32)
    {
        return files.Select(file =>
        {
            var child = Path.GetDirectoryName(file.FileName);
            if (child == null)
                return Upload(file, root, folder, len: len);

            var path = Path.Combine(root, folder, child);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Upload(file, root, Path.Combine(folder, child), child, len - child.Length - 1);
        });
    }

    public static IEnumerable<Upload> UploadFolder(IEnumerable<IFormFile> files, string folder = "images",
        int len = 32)
    {
        var root = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        return UploadFolder(files, root, folder, len);
    }
}