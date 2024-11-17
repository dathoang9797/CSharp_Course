using System.Data;
using System.Net.Http.Json;
using AppCrawler;
using Dapper;
using Microsoft.Data.SqlClient;
using Attribute = AppCrawler.Attribute;


const string rootDir = @"E:\CShrap-Course\TTTH\Module_4\AppCrawler\";

async Task<Book?> GetBook(string id)
{
    var baseUri = new Uri("https://tiki.vn/api/v2/");
    using var client = new HttpClient();
    client.BaseAddress = baseUri;
    var book = await client.GetFromJsonAsync<Book>($"products/{id}");
    return book;
}

var filePathTiki = Path.Combine(rootDir, "tiki.txt");
var listId = File.ReadAllLines(filePathTiki);
var listBook = new List<Book>();
var dictCat = new Dictionary<int, Category>();
var dictAuthor = new Dictionary<int, Author>();
var dictAttribute = new Dictionary<string, Attribute>();
var context = new EbookContext();

// if (listId.Length != 0)
// {
//     foreach (var id in listId.Distinct())
//     {
//         var book = await GetBook(id);
//         if (book != null)
//         {
// var keyCategory = book.Categories.Id;
// if (!dictCat.ContainsKey(keyCategory))
//     dictCat[keyCategory] = book.Categories;
//
// if (book.Authors != null)
//     foreach (var author in book.Authors)
//     {
//         var keyAuthor = author.Id;
//         if (!dictAuthor.ContainsKey(keyAuthor))
//             dictAuthor[keyAuthor] = author;
//     }
//
// foreach (var bookAttribute in book.Specifications)
// {
//     for (var i = 0; i < bookAttribute.Attributes.Count; i++)
//     {
//         var keyAttr = bookAttribute.Attributes[i].Code;
//         if (!dictAttribute.ContainsKey(keyAttr))
//             dictAttribute[keyAttr] = bookAttribute.Attributes[i];
//     }
// }
// listBook.Add(book);
// }
// }
// }

// const string connect = "server=localhost;user id=sa;password=<YourStrong@Passw0rd>;database=Ebook;Trusted_Connection=false;TrustServerCertificate=true";
// using IDbConnection connection = new SqlConnection(connect);
// const string sql1 = "SET IDENTITY_INSERT Author ON; INSERT INTO Author (AuthorId, AuthorName, Slug) VALUES (@Id, @Name, @Slug); SET IDENTITY_INSERT Author OFF;";
// connection.Execute(sql1, dictAuthor.Values);

// context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Author] ON");
// await context.Authors.AddRangeAsync(dictAuthor.Values);
// context.SaveChanges();
// context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Author] OFF");
// Console.WriteLine("Finished Author");
//
// context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Category] ON");
// await context.Categories.AddRangeAsync(dictCat.Values);
// context.SaveChanges();
// context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Category] OFF");
// Console.WriteLine("Finished Categories");
//
// context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Attribute] ON");
// await context.Attributes.AddRangeAsync(dictAttribute.Values);
// context.SaveChanges();
// context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Attribute] OFF");
// Console.WriteLine("Finished Attribute");

if (listId.Length != 0)
{
    foreach (var id in listId)
    {
        var book = await GetBook(id);
        if (book != null)
        {
            listBook.Add(book);
        }
    }
}

if (listBook.Any())
{
    await context.Books.AddRangeAsync(listBook);
    await context.SaveChangesAsync(); // Commit the changes to the database
    Console.WriteLine($"{listBook.Count} books added successfully!");
}

// var content = await client.GetStringAsync("products/103512039");
// var filePath = Path.Combine(rootDir, "book.json");
// if (!string.IsNullOrWhiteSpace(content))
//     File.WriteAllText(filePath, content);