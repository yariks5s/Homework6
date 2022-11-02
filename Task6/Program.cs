using System.Text.Json;
using System.Text.Json.Serialization;


string path = @"C:\Users\bryuh\RiderProjects\ConsoleApp1\Task6\bin\Debug\net6.0\data.json";
using (FileStream fs = new FileStream(path, FileMode.Open))
{
    var books = await JsonSerializer.DeserializeAsync<List<Book1>>(fs);
    foreach (var book in books)
    {
        Console.WriteLine($"{book.PublishingHouseId} - {book.Title} - {book.PublishingHouse.Adress}");
    }
}


// --------Task1--------
public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class Book
{
    public int PublishingHouseId { get; set; }
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
}


// --------Task2--------
public class PublishingHouse1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class Book1
{
    
    public string Title { get; set; }
    public PublishingHouse1 PublishingHouse { get; set; }
    [JsonIgnore] public int PublishingHouseId { get; set; }
}

// --------Task3--------
public class PublishingHouse2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class Book2
{
    
    public string Title { get; set; }
    public PublishingHouse2 PublishingHouse { get; set; }
    [JsonIgnore] public int PublishingHouseId { get; set; }
}


// --------If we want to have PublishingHouseId without serializing it manually--------
public class PublishingHouse3
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class Book3
{
    [JsonPropertyName("Name")]
    public string Title { get; set; }
    public PublishingHouse3 PublishingHouse { get; set; }
    [JsonIgnore]
    public int PublishingHouseId
    {
        get
        {
            return PublishingHouse.Id;
        }
    }
}