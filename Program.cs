using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Deserializer.Models;

var opt = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true //ignores case sensitivity
};

HttpClient client = new()
{
    BaseAddress = new Uri("http://localhost:5043")
};

// helper to deserialise JSON response
var temperatures = await client.GetFromJsonAsync<Temperature[]>("/weatherforecast", opt);
if (temperatures != null)
{
    foreach (var temperature in temperatures)
    {
        Console.WriteLine($"Summary: {temperature.Summary}");
    }
}

// The code below will also deserialize an API response without a helper
//var response = await client.GetAsync("/weatherforecast");

//if (response.IsSuccessStatusCode)
//{
//    // create a collection of temperatures
//    var temperatures = await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), opt);
//    if (temperatures != null)
//    {
//        foreach(var temperature in temperatures)
//        {
//            Console.WriteLine($"Summary: {temperature.Summary}");
//        }
//    }

//}
//else
//{
//    Console.WriteLine($" Whoops, something went wrong: {response.StatusCode}");
//}