using System.Text.Json.Serialization;
namespace Deserializer.Models
{
    public class Person
    {
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] // to ignore the property with a condition (conditional formatting)
        public string? Name { get; set; }

        [JsonPropertyName("surname")] // how to name the serialised property as something else
        public string? LastName { get; set; }
        public int Age { get; set; }

        [JsonIgnore] // to exclude property from serialised object
        public bool isAlive { get; set; }
        public Address? Address { get; set; }
        public List<Phone>? Phones { get; set; }
    }
}