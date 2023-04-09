# Harvest Time Tracking .NET Client Library

The Harvest Time Tracking .NET Client Library is made up of the following main components:

- `HarvestServiceClient` - The main client object that handles building requests, sending them to the Harvest API, and processing the responses.
- `AuthCredential` - The authentication object that contains your OAuth2 or PAT credentials to authenticate requests to the Harvest API.
- `HarvestRequestAdapter` - The HTTP provider that handles sending requests to the Harvest API.
- `RequestBuilder` - The objects that build the requests to the Harvest API including the URL, method, headers, query, and body.

The library is designed to be customizable and extensible. You can bring together the components you need to build a client that works for your application.

The documentation provided here covers basic scenarios and examples using the [Harvest API Documentation](https://help.getharvest.com/api-v2/).

## Contents

- [HarvestServiceClient](#harvestserviceclient)
  - [AuthCredential](#authcredential)
- [Requests](#requests)
  - [Request Builders](#request-builders)
  - [Request Calls](#request-calls)
  - [Request Query Parameters](#request-query-parameters)
  - [Pagination](#pagination)

## HarvestServiceClient

To start making requests with the library, you will need to initialize a `HarvestServiceClient` instance.

| Parameter | Required? | Default Value |
|:-|:-|:-|
| `AuthCredential` authCredential | Yes | n/a |
| `string` applicationId | Yes | n/a |

The `authCredential` parameter is an instance of the `AuthCredential` object that contains your OAuth2 or PAT credentials to authenticate requests to the Harvest API.

The `applicationId` parameter is a string that identifies your application. This is used as the `User-Agent` header when making requests to the Harvest API.

### AuthCredential

The `AuthCredential` object comes in two flavors:

**OAuthCredential**

The `OAuthCredential` object is used to authenticate your application using the OAuth2 flow. It contains the following properties:

| Parameter | Required? | Default Value |
|:-|:-|:-|
| `string` clientId | Yes | n/a |
| `string` clientSecret | Yes | n/a |
| `Uri` redirectUri` | Yes | n/a |
| `AccessToken` accessToken | No | `null` |
| `string` scopes | No | `harvest:all` |
| `string` responseType` | No | `code` |

```csharp
AuthCredential credential = new OAuthCredential("clientId", "clientSecret", new Uri("redirectUri");

HarvestServiceClient harvestClient = new HarvestServiceClient(credential, "MyHarvestOAuthApp");
```

To authenticate your application using the OAuth2 flow, you will need to first build the authorization URL using the `BuildAuthorizationUrl` method on the `HarvestServiceClient` instance. This will return a `Uri` that you can use to redirect the user to the Harvest login page.

For more information on implementing the OAuth2 flow, see our [Authentication Documentation](authentication.md).

**PATCredential**

The `PATCredential` object is used to authenticate your application using a personal access token. It contains the following properties:

| Parameter | Required? | Default Value |
|:-|:-|:-|
| `string` accessToken | Yes | n/a |

```csharp
AuthCredential credential = new PATCredential("accessToken");

HarvestServiceClient harvestClient = new HarvestServiceClient(credential, "MyHarvestPATApp");
```

Using a personal access token, you will now be able to make requests to the Harvest API.

## Requests

To make requests against the Harvest API, you will need to use the `HarvestServiceClient` instance to build a request from one of the many request builders based on the endpoint you want to call. These request builders are designed to follow the same pattern as the Harvest API endpoints.

For more information on the requests available in the SDK, see our [Requests Documentation](requests.md).

### Request Builders

For example, to get a request builder for the `/projects` endpoint, you call:

| API | SDK | URL |
|:-|:-|:-|
| Projects | harvestServiceClient.Projects | api.harvestapp.com/v2/projects |

The SDK will return a `ProjectsRequestBuilder` instance that you can use to build a request. From there, you can continue to chain request builders and methods to build the request you want to make.

### Request Calls

From the above example using the `/projects` endpoint, you can build a request to get a list of projects by calling:

```csharp
ProjectsResponse projects = await harvestServiceClient
    .Projects
    .GetAsync();
```

Any errors that occur during the request will be thrown as an exception as you would making calls with a standard `HttpClient`.

### Request Query Parameters

The request builders also provide methods to add query parameters to the request. For example, to get a list of projects with a specific client ID, you can call:

```csharp
ProjectsResponse projects = await harvestServiceClient
    .Projects
    .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.ClientId = 123456);
```

### Pagination

When listing entries from the Harvest API, the response will be paginated. You can use the `QueryParameters` in the request configuration to specify the page and per page parameters.

```csharp
ProjectsResponse projects = await harvestServiceClient
    .Projects
    .GetAsync(requestConfiguration => {
        requestConfiguration.QueryParameters.PerPage = 100;
        requestConfiguration.QueryParameters.Page = 1);
    }
```

The responses from the request will also contain the pagination information which can be used to retrieve the next page of results.

| Property | Description |
|:-|:-|
| `int` PerPage | The total number of entries per page |
| `int` TotalPages | The total number of pages |
| `int` TotalEntries | The total number of entries |
| `int` Page | The current page number |
