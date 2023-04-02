namespace Harvest.Common.Serialization;

using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

/// <summary>
/// Defines a converter for converting an enum to a string value based on the <see cref="EnumStringValueAttribute"/>.
/// </summary>
internal class EnumStringValueConverter : StringEnumConverter
{
    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">Cannot convert enum to string value.</exception>
    /// <exception cref="AmbiguousMatchException">More than one of the <see cref="EnumStringValueAttribute"/> was found.</exception>
    /// <exception cref="TypeLoadException">The <see cref="EnumStringValueAttribute"/> type cannot be loaded.</exception>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Type type = value.GetType();
        string name = Enum.GetName(type, value);
        if (name == null)
        {
            throw new InvalidOperationException("Cannot convert enum to string value without name.");
        }

        FieldInfo field = type.GetField(name);
        if (field == null ||
            Attribute.GetCustomAttribute(field, typeof(EnumStringValueAttribute)) is not EnumStringValueAttribute
                attr)
        {
            throw new InvalidOperationException(
                "Cannot convert enum to string value without EnumStringValueAttribute.");
        }

        writer.WriteValue(attr.Value);
    }

    /// <inheritdoc />
    /// <exception cref="TypeLoadException">The <see cref="EnumStringValueAttribute"/> type cannot be loaded.</exception>
    /// <exception cref="AmbiguousMatchException">More than one of the <see cref="EnumStringValueAttribute"/> was found.</exception>
    /// <exception cref="InvalidOperationException">Cannot convert string value to enum.</exception>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value == null)
        {
            return null;
        }

        string value = reader.Value.ToString();
        foreach (FieldInfo field in objectType.GetFields())
        {
            if (Attribute.GetCustomAttribute(field, typeof(EnumStringValueAttribute)) is not EnumStringValueAttribute
                attr)
            {
                continue;
            }

            if (attr.Value == value)
            {
                return field.GetValue(null);
            }
        }

        throw new InvalidOperationException("Cannot convert string value to enum without EnumStringValueAttribute.");
    }

    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return objectType.IsEnum;
    }
}