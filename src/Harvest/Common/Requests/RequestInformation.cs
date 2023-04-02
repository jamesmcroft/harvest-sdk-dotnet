namespace Harvest.Common.Requests;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Extensions;
using Newtonsoft.Json;
using Tavis.UriTemplates;

/// <summary>
/// Defines an abstract HTTP request.
/// </summary>
public class RequestInformation
{
    private const string ContentTypeHeader = "Content-Type";
    private Uri rawUri;

    /// <summary>
    /// Gets or sets the URI for the request.
    /// </summary>
    /// <exception cref="InvalidOperationException" accessor="get">Thrown when the base URL is not set.</exception>
    /// <exception cref="ArgumentNullException" accessor="set">Thrown when the <paramref name="value"/> is <see langword="null"/>.</exception>
    public Uri URI
    {
        get
        {
            if (this.rawUri != null)
            {
                return this.rawUri;
            }

            if (this.PathParameters.TryGetValue("request-raw-url", out object rawUrl) && rawUrl is string rawUrlString)
            {
                this.rawUri = new Uri(rawUrlString);
                return this.rawUri;
            }

            if (this.UrlTemplate.IndexOf("{+baseurl}", StringComparison.OrdinalIgnoreCase) >= 0 &&
                !this.PathParameters.ContainsKey("baseurl"))
            {
                throw new InvalidOperationException("The base URL is not set.");
            }

            var parsedUrlTemplate = new UriTemplate(this.UrlTemplate);
            foreach (KeyValuePair<string, object> urlTemplateParameter in this.PathParameters)
            {
                parsedUrlTemplate.SetParameter(urlTemplateParameter.Key,
                    GetSanitizedValue(urlTemplateParameter.Value));
            }

            foreach (KeyValuePair<string, object> queryStringParameter in this.QueryParameters)
            {
                parsedUrlTemplate.SetParameter(queryStringParameter.Key,
                    GetSanitizedValue(queryStringParameter.Value));
            }

            return new Uri(parsedUrlTemplate.Resolve());
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.QueryParameters.Clear();
            this.PathParameters.Clear();
            this.rawUri = value;
        }
    }

    /// <summary>
    /// Gets or sets the URL template for the request.
    /// </summary>
    public string UrlTemplate { get; set; }

    /// <summary>
    /// Gets or sets the path parameters to use for the URL template when generating the URI.
    /// </summary>
    public IDictionary<string, object> PathParameters { get; set; } =
        new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Gets or sets the HTTP method for the request.
    /// </summary>
    public Method HttpMethod { get; set; }

    /// <summary>
    /// Gets or sets the query parameters for the request.
    /// </summary>
    public IDictionary<string, object> QueryParameters { get; set; } =
        new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Gets or sets the headers for the request.
    /// </summary>
    public Headers Headers { get; set; } = new();

    /// <summary>
    /// Gets or sets the request body content.
    /// </summary>
    public Stream Content { get; set; } = Stream.Null;

    private JsonSerializerSettings JsonSerializerSettings { get; } = new()
    {
        NullValueHandling = NullValueHandling.Ignore,
        DateFormatHandling = DateFormatHandling.IsoDateFormat,
        DateTimeZoneHandling = DateTimeZoneHandling.Utc
    };

    /// <summary>
    /// Adds query parameters from a source object that has properties decorated with the <see cref="QueryParameterAttribute"/> attribute.
    /// </summary>
    /// <param name="source">The source object to add query parameters from.</param>
    public void AddQueryParameters(object source)
    {
        if (source == null)
        {
            return;
        }

        foreach ((string Name, object Value) property in source.GetType()
                     .GetProperties()
                     .Select(
                         prop => (
                             Name: prop.GetCustomAttributes(false)
                                 .OfType<QueryParameterAttribute>()
                                 .FirstOrDefault()?.TemplateName ?? prop.Name.ToFirstCharacterLowerCase(),
                             Value: prop.GetValue(source)
                         )
                     )
                     .Where(queryProp => queryProp.Value != null &&
                                         !this.QueryParameters.ContainsKey(queryProp.Name) &&
                                         !string.IsNullOrEmpty(queryProp.Value.ToString()) &&
                                         (queryProp.Value is not ICollection collection ||
                                          collection.Count > 0)))
        {
            this.QueryParameters.AddOrReplace(property.Name, property.Value);
        }
    }

    /// <summary>
    /// Adds headers to the request.
    /// </summary>
    /// <param name="headers">The headers to add.</param>
    public void AddHeaders(Headers headers)
    {
        if (headers == null)
        {
            return;
        }

        this.Headers.AddAll(headers);
    }

    /// <summary>
    /// Sets the request body content to a JSON representation of the specified item.
    /// </summary>
    /// <typeparam name="T">The type of item to serialize as JSON.</typeparam>
    /// <param name="item">The item to serialize.</param>
    public void SetJsonContent<T>(T item)
    {
        this.Headers.Add(ContentTypeHeader, "application/json");
        this.Content = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item, this.JsonSerializerSettings)));
    }

    private static object GetSanitizedValue(object value)
    {
        return value switch
        {
            bool boolean => boolean.ToString().ToLower(),
            DateTimeOffset dateTimeOffset => dateTimeOffset.ToString("o"),
            DateTime dateTime => dateTime.ToString("o"),
            _ => value
        };
    }
}