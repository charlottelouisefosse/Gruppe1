using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Gruppe1.Service;

partial class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")); // Aksepterer JSON-respons
        client.DefaultRequestHeaders.Add("User-Agent", "PollenAPIClient");

        await ProcessRepositoriesAsync(client);
    }

    static async Task ProcessRepositoriesAsync(HttpClient client)
    {
        var url = "https://pollen.googleapis.com/v1/forecast:lookup?location.latitude=59.26754&location.longitude=10.40762&days=5&key=AIzaSyCcJ3vf6FXeMkfgdGuJytfRuh6PQ_tDJ7U";
        var response = await client.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}