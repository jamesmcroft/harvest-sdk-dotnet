namespace Harvest.Common.Requests;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Authentication;
using Extensions;
using Newtonsoft.Json;

/// <summary>
/// Defines the request adapter instance for use with the Harvest API.
/// </summary>
public class HarvestRequestAdapter : IDisposable
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="HarvestRequestAdapter"/> class with the specified authentication credential.
    /// </summary>
    /// <param name="credential">The authentication credential used to authenticate the client.</param>
    /// <param name="httpClient">The HTTP client used to send requests.</param>
    public HarvestRequestAdapter(AuthCredential credential, HttpClient httpClient = null)
    {
        this.Credential = credential;
        this.httpClient = httpClient ?? new HttpClient();
    }

    /// <summary>
    /// Gets the authentication credential used to authenticate the client.
    /// </summary>
    protected internal AuthCredential Credential { get; }

    /// <summary>
    /// Gets or sets the base URL for every request.
    /// </summary>
    public string BaseUrl { get; set; }

    /// <summary>
    /// Gets or sets the base headers for every request.
    /// </summary>
    public Headers Headers { get; } = new();

    /// <inheritdoc />
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the object.
    /// </summary>
    /// <param name="disposing">A value indicating whether the object is disposing.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.httpClient.Dispose();
        }
    }

    /// <summary>
    /// Sends a request to the Harvest API with a response of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of response returned by the request.</typeparam>
    /// <param name="requestInfo">The request information to send.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no response after sending the request.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the requestInfo is <see langword="null"/>.</exception>
    public async Task<T> SendAsync<T>(RequestInformation requestInfo, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await this.GetHttpResponseMessageAsync(requestInfo, cancellationToken);
        requestInfo.Content?.Dispose();
        string responseContent = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        throw new HttpRequestException(responseContent);
    }

    /// <summary>
    /// Sends a request to the Harvest API with no expected response.
    /// </summary>
    /// <param name="requestInfo">The request information to send.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no response after sending the request.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the requestInfo is <see langword="null"/>.</exception>
    public async Task SendAsync(RequestInformation requestInfo, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await this.GetHttpResponseMessageAsync(requestInfo, cancellationToken);
        requestInfo.Content?.Dispose();
        string responseContent = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(responseContent);
        }
    }

    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="requestInfo"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no response after sending the request.</exception>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    private async Task<HttpResponseMessage> GetHttpResponseMessageAsync(
        RequestInformation requestInfo,
        CancellationToken cancellationToken)
    {
        if (requestInfo == null)
        {
            throw new ArgumentNullException(nameof(requestInfo));
        }

        using HttpRequestMessage message = this.GetRequestMessageFromRequestInformation(requestInfo);
        await this.Credential.AuthenticateRequestAsync(message);
        HttpResponseMessage response = await this.httpClient.SendAsync(message, cancellationToken);
        if (response == null)
        {
            throw new InvalidOperationException("Could not get a response after sending the request.");
        }

        return response;
    }

    private HttpRequestMessage GetRequestMessageFromRequestInformation(RequestInformation requestInfo)
    {
        requestInfo.PathParameters.AddOrReplace("baseurl", this.BaseUrl);

        Uri requestUri = requestInfo.URI;
        var message = new HttpRequestMessage
        {
            Method = new HttpMethod(requestInfo.HttpMethod.ToString().ToUpperInvariant()), RequestUri = requestUri
        };

        if (requestInfo.Content != null && requestInfo.Content != Stream.Null)
        {
            message.Content = new StreamContent(requestInfo.Content);
        }

        Headers headers = this.Headers;
        if (headers != null && headers.Any())
        {
            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                if (!message.Headers.TryAddWithoutValidation(header.Key, header.Value) && message.Content != null)
                {
                    message.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
        }

        if (!(requestInfo.Headers?.Any() ?? false))
        {
            return message;
        }

        foreach (KeyValuePair<string, IEnumerable<string>> header in requestInfo.Headers)
        {
            if (!message.Headers.TryAddWithoutValidation(header.Key, header.Value) && message.Content != null)
            {
                message.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        return message;
    }
}