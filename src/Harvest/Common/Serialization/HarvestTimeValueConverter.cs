namespace Harvest.Common.Serialization;

using System;
using System.Globalization;
using Newtonsoft.Json;

/// <summary>
/// Defines a converter for converting a <see cref="TimeSpan"/> to a string value in the format "h:mmtt".
/// </summary>
internal class HarvestTimeValueConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value is not TimeSpan time)
        {
            writer.WriteNull();
            return;
        }

        DateTime dateTime = DateTime.Today.Add(time);
        string timeString = dateTime.ToString("h:mmtt", CultureInfo.InvariantCulture).ToLowerInvariant();
        writer.WriteValue(timeString);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.Value is not string value)
        {
            return null;
        }

        if (DateTime.TryParseExact(
                value,
                "h:mmtt",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime dateTime))
        {
            return dateTime.TimeOfDay;
        }

        return null;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(TimeSpan);
    }
}