// can generate object/properties from JSON using quicktype.io OR
// using Visual Studio's option Edit > Paste Special > Paste JSON as classes
namespace Deserializer.Models
{
    public partial class Temperature
    {
        public DateTimeOffset Date { get; set; }

        public long TemperatureC { get; set; }

        public string? Summary { get; set; }

        public long TemperatureF { get; set; }
    }
}