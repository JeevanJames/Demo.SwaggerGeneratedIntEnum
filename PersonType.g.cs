using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwaggerGeneratedIntEnum;

[JsonConverter(typeof(PersonTypeJsonConverter))]
public readonly partial struct PersonType
{
    // The ctor can generate code to ensure that the numeric value is valid.
    private PersonType(int value)
    {
        if (value is not (0 or 1 or 2))
            throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    public int Value { get; }

    public static implicit operator int(PersonType personType) => personType.Value;

    public static implicit operator PersonType(int value) => new(value);

    // These are the default generated values.
    // A partial struct can be created to define proper fields for the enum values.
    public static readonly PersonType _0 = 0;
    public static readonly PersonType _1 = 1;
    public static readonly PersonType _2 = 2;
}

public sealed class PersonTypeJsonConverter : JsonConverter<PersonType>
{
    public override PersonType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // The specific GetIntXX method can be determined based on the "format" value from the Open
        // API definition.
        return reader.GetInt32();
    }

    public override void Write(Utf8JsonWriter writer, PersonType value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}