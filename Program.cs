using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text;

Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;

string json = File.ReadAllText("books.json");
var books = JsonSerializer.Deserialize<List<Book>>(json);

foreach (var b in books!)
    Console.WriteLine($"{b.Title} - {b.PublishingHouse.Name} ({b.PublishingHouse.Adress})");

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};
Console.WriteLine(JsonSerializer.Serialize(books, options));

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Adress { get; set; } = "";
}

class Book
{
    // Питання 1: щоб не серіалізувати PublishingHouseId, розкоментувати:
    //[JsonIgnore]
    public int PublishingHouseId { get; set; }

    // Питання 2: щоб Title серіалізувався як "Name", розкоментувати:
    //[JsonPropertyName("Name")]
    public string Title { get; set; } = "";
    public PublishingHouse PublishingHouse { get; set; } = new();
}