using System.Net.Http.Json;
using System.Net.Mime;
using AppCrawler;

var baseUri = new Uri("https://tiki.vn/api/v2/");
using var client = new HttpClient();
client.BaseAddress = baseUri;

var content = await client.GetStringAsync("products/103512039");
var filePath = Path.Combine(@"E:\CShrap-Course\TTTH\Module_4\AppCrawler\", "book.json");
if (!string.IsNullOrWhiteSpace(content))
    File.WriteAllText(filePath, content);

var book = await client.GetFromJsonAsync<Book>("products/103512039");
if (book != null)
{
    Console.WriteLine(book);
}