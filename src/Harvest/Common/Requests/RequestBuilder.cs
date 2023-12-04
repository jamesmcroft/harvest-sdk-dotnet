namespace Harvest.Common.Requests;

using System;
using System.Collections.Generic;

/// <summary>
/// Defines the builder for a request.
/// </summary>
public abstract class RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="urlTemplate">The URL template to use to build the request URL.</param>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    protected RequestBuilder(
        string urlTemplate,
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = urlTemplate;
        this.PathParameters = new Dictionary<string, object>(pathParameters);
        this.RequestAdapter = requestAdapter;
    }

    /// <summary>
    /// Gets the path parameters to use to build the request URL.
    /// </summary>
    protected Dictionary<string, object> PathParameters { get; }

    /// <summary>
    /// Gets the request adapter to use to execute the requests.
    /// </summary>
    protected HarvestRequestAdapter RequestAdapter { get; }

    /// <summary>
    /// Gets the URL template to use to build the request URL.
    /// </summary>
    protected string UrlTemplate { get; }

    /// <summary>
    /// Builds the request to get a resource.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of request configuration.</typeparam>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>The request information object.</returns>
    public RequestInformation ToGetRequestInformation<TConfiguration>(
        Action<TConfiguration> requestConfiguration = default)
        where TConfiguration : RequestConfiguration, new()
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.GET,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("Accept", "application/json");

        return ConfigureRequest(requestConfiguration, requestInfo);
    }

    /// <summary>
    /// Builds the request to post a resource.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of request configuration.</typeparam>
    /// <param name="body">The request body.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public RequestInformation ToPostRequestInformation<TConfiguration>(
        object body,
        Action<TConfiguration> requestConfiguration)
        where TConfiguration : RequestConfiguration, new()
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.POST,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters
        };

        requestInfo.Headers.Add("Accept", "application/json");

        requestInfo.SetJsonContent(body);

        return ConfigureRequest(requestConfiguration, requestInfo);
    }

    /// <summary>
    /// Builds the request to patch a resource.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of request configuration.</typeparam>
    /// <param name="body">The request body.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToPatchRequestInformation<TConfiguration>(
        object body,
        Action<TConfiguration> requestConfiguration)
        where TConfiguration : RequestConfiguration, new()
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.PATCH,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("Accept", "application/json");

        requestInfo.SetJsonContent(body);

        return ConfigureRequest(requestConfiguration, requestInfo);
    }

    /// <summary>
    /// Builds the request to delete a resource.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of request configuration.</typeparam>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToDeleteRequestInformation<TConfiguration>(
        Action<TConfiguration> requestConfiguration)
        where TConfiguration : RequestConfiguration, new()
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.DELETE,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters,
        };

        return ConfigureRequest(requestConfiguration, requestInfo);
    }

    /// <summary>
    /// Configures the result request information using the specified request configuration.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of configuration.</typeparam>
    /// <param name="requestConfiguration">The requested configuration.</param>
    /// <param name="requestInfo">The request information object.</param>
    /// <returns>The configured request information object.</returns>
    protected static RequestInformation ConfigureRequest<TConfiguration>(
        Action<TConfiguration> requestConfiguration,
        RequestInformation requestInfo)
        where TConfiguration : RequestConfiguration, new()
    {
        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new TConfiguration();
        requestConfiguration.Invoke(requestConfig);

        if (requestConfig is QueryableRequestConfiguration queryable)
        {
            requestInfo.AddQueryParameters(queryable.GetQueryParameters());
        }

        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }
}