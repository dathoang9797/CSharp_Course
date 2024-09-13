using System.Data;
using Crawler;
using Dapper;
using HtmlAgilityPack;
using Microsoft.Data.SqlClient;

var url =
    "https://www.uefa.com/euro2024/news/0275-151eb1c333ea-d30deec67b13-1000--uefa-euro-2024-results-when-and-where-were-the-matches/";
var web = new HtmlWeb();
var doc = web.Load(url);

var h2s = doc.DocumentNode.SelectNodes("//h2");

// Console.WriteLine(h2s.Count);
int[] arr = { 0, 1, 2, 2, 4, 14 };
var cnt = 1;
var listMatch = new List<Match>();
foreach (var h2 in h2s.Skip(3).Take(5))
{
    var ps = h2.SelectNodes("./following-sibling::p").Skip(arr[cnt - 1]).Take(arr[cnt]);
    // Console.WriteLine(ps.Count());
    foreach (var p in ps)
    {
        var date = p.SelectSingleNode("b");
        if (date != null)
        {
            var brr = p.SelectNodes("a");
            if (brr.Count > 0)
            {
                var n = brr.Count / 2;
                for (var i = 0; i < n; i++)
                {
                    // Console.WriteLine($"Ti so 2 doi: {brr[2 * i].InnerText}");
                    // Console.WriteLine($"San van dong:{}");
                    var trr = brr[2 * i].InnerText.Split(" ");
                    var srr = trr[1].Split("-");
                    var obj = new Match
                    {
                        Date = date.InnerText,
                        Stadium = brr[2 * i + 1].InnerText,
                        Team1 = trr[0],
                        Team2 = trr[2],
                        Goals1 = Convert.ToByte(srr[0]),
                        Goals2 = Convert.ToByte(srr[1])
                    };
                    listMatch.Add(obj);
                }
            }
            // Console.WriteLine($"Ngay: {date.InnerText}");
        }
    }

    cnt++;
}

Console.WriteLine(string.Join(", ", listMatch));

// var connectionString = "server=localhost;user id=sa;password=<YourStrong@Passw0rd>;database=Euro";
// var sql = "INSERT INTO PlayerTemp(TeamId, ClubName, FullName, DateOfBirth, Goals, Caps, Position) VALUES (@TeamId, @ClubName, @FullName, @DateOfBirth, @Goals, @Caps, @Postion)";
// using (IDbConnection connection = new SqlConnection(connectionString))
// {
//     connection.Execute("INSERT INTO Team(TeamName, GroupName) VALUES (@TeamName, @GroupName)", teams);
// connection.Execute(sql, listMatch);
// }