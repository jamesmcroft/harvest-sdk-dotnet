namespace Harvest.Common.Serialization;

using System;

[AttributeUsage(AttributeTargets.Field)]
internal class EnumStringValueAttribute : Attribute
{
    public EnumStringValueAttribute(string value)
    {
        this.Value = value;
    }

    public string Value { get; }
}
