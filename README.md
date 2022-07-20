# Demo - Generated code for OpenAPI numeric enum
This code demonstrates an alternate way to generate C# code for numeric enums defined in an OpenAPI or Swagger definition.

Given the following C# enum:

```cs
public enum PersonType
{
    Employee,
    Customer,
    Student
}
```

Depending on the JSON serialization settings, this enum may be defined in the OpenAPI definition as a `string` enum or a numeric enum.

A string enum would look like this:
```json
"PersonType": {
    "enum": [
        "Employee",
        "Customer",
        "Student"
    ],
    "type": "string"
}
```

A numeric enum would look like this:
```json
"PersonType": {
    "enum": [
        0,
        1,
        2
    ],
    "type": "number",
    "format": "int32"
}
```

With the string enum definition, it is easy to generate a normal C# enum type. However, for the numeric enum, we would normally get an enum like this:
```cs
public enum PersonType
{
    _0 = 0,
    _1 = 1,
    _2 = 2
}
```

Unfortunately, that's all we can generate as there is no further information in the OpenAPI definition. The only solution is to allow the developer to augment the generated code with the proper member names by using the partial type feature of C#.

If C# supported partial enums, then we could just create a partial enum that has the proper members:
```cs
// This will not compile

// Generated code
public partial enum PersonType
{
    _0 = 0,
    _1 = 1,
    _2 = 2
}

// Created by developer
public partial enum PersonType
{
    Employee = 0,
    Customer = 1,
    Student = 2
}
```

However, since this is not supported, we have to resort to using a custom struct. See the files `PersonType.g.cs` which is the generated code and `PersonType.Partial.cs`, which is the partial portion created by the developer with the actual member names.