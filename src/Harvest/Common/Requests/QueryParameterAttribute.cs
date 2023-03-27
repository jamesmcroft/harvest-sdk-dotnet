namespace Harvest.Common.Requests;

using System;

/// <summary>
/// Defines an attribute that allows mapping between the query parameter name in a template and a property name in a class.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class QueryParameterAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="QueryParameterAttribute"/> class.
    /// </summary>
    /// <param name="templateName">The name of the parameter in the template.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="templateName"/> is <see langword="null"/>.</exception>
    public QueryParameterAttribute(string templateName)
    {
        if (string.IsNullOrEmpty(templateName))
        {
            throw new ArgumentNullException(nameof(templateName));
        }

        this.TemplateName = templateName;
    }

    /// <summary>
    /// Gets the name of the parameter in the template.
    /// </summary>
    public string TemplateName { get; }
}