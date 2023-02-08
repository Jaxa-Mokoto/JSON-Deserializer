using System.Net.Http;
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

var response = await client.GetAsync("/weatherforecast");

if (response.IsSuccessStatusCode)
{
    // create a collection of temperatures
    var temperatures = await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), opt);
    if (temperatures != null)
    {
        foreach(var temperature in temperatures)
        {
            Console.WriteLine($"Summary: {temperature.Summary}");
        }
    }

}
else
{
    Console.WriteLine($" Whoops, something went wrong: {response.StatusCode}");
}