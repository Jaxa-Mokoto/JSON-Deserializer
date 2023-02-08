using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Deserializer.Models;

// uncomment to use for option 1 and option 2
//var opt = new JsonSerializerOptions
//{
//    PropertyNameCaseInsensitive = true //ignores case sensitivity
//};

HttpClient client = new()
{
    BaseAddress = new Uri("http://localhost:5043")
};

// 1. The code below will use a helper to deserialise JSON response (option 1)
//var temperatures = await client.GetFromJsonAsync<Temperature[]>("/weatherforecast", opt);
//if (temperatures != null)
//{
//    foreach (var temperature in temperatures)
//    {
//        Console.WriteLine($"Summary: {temperature.Summary}");
//    }
//}

// 2. The code below will also deserialize an API response without a helper (option 2)
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

// 3. JSON Document Deserialisation (option 3) 
var response = await client.GetAsync("/weatherforecast");

if (response.IsSuccessStatusCode)
{
    // puts unserialised json data into the jsonString variable
    var jsonString = await response.Content.ReadAsStringAsync();

    using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString))
    {
        JsonElement root = jsonDocument.RootElement;

        foreach (var temperature in root.EnumerateArray())
        {
            Console.WriteLine(temperature.GetProperty("summary").ToString()); // should not use magic string like this.
        }
    }
}
else
{
    Console.WriteLine($" Whoops, something went wrong: {response.StatusCode}");
}