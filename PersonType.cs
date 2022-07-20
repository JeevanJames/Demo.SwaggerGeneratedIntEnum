using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwaggerGeneratedIntEnum;

[JsonConverter(typeof(PersonTypeJsonConverter))]
public readonly partial struct PersonType
{
    private PersonType(int value)
    {
        if (value is < 0 or > 2)
            throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(PersonType personType) => personType.Value;

    public static implicit operator PersonType(int value) => new(value);

    public static readonly PersonType _0 = 0;
    public static readonly PersonType _1 = 1;
    public static readonly PersonType _2 = 2;
}

public readonly partial struct PersonType
{
    public static readonly PersonType Employee = 0;
    public static readonly PersonType Customer = 1;
    public static readonly PersonType General = 2;
}

public sealed class PersonTypeJsonConverter : JsonConverter<PersonType>
{
    public override PersonType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, PersonType value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}