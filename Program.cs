using System.Text.Json;
using SwaggerGeneratedIntEnum;

using static System.Console;

Person person = new()
{
    Name = "Jeevan James",
    Company = "Eurofins",
    Type = PersonType.Customer,
};

string json = JsonSerializer.Serialize(person, new JsonSerializerOptions
{
    WriteIndented = true,
});
WriteLine(json);

Person? deserializedPerson = JsonSerializer.Deserialize<Person>(json);
if (deserializedPerson is null)
    WriteLine("Could not deserialize the JSON.");
else
{
    WriteLine("Successfully deserialized JSON:");
    WriteLine($"Name   : {deserializedPerson.Name}");
    WriteLine($"Company: {deserializedPerson.Company}");
    WriteLine($"Type   : {deserializedPerson.Type.Value}");
}
