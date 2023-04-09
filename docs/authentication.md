# Authentication Examples

This document is aimed at helping users of the Harvest .NET SDK to authenticate their applications with the Harvest API.

> **Note:** If you have examples you would like to add to this document, please submit a pull request!

## Contents

- [OAuth2](#oauth2)
  - [WPF Desktop Application](#wpf-desktop-application)
- [Personal Access Token](#personal-access-token)
  - [.NET App (Console, Web API, etc.)](#net-app-console-web-api-etc)

## OAuth2

### WPF Desktop Application

The following example shows how to authenticate a WPF desktop application using the OAuth2 flow.

```csharp
// Using a WebView2 control to display the OAuth2 login page
string redirectUrl = "https://localhost:5001";
Uri redirectUri = new Uri(redirectUrl);
AuthCredential credential = new OAuthCredential("clientId", "clientSecret", new Uri(redirectUri);
HarvestServiceClient harvestClient = new HarvestServiceClient(credential, "MyHarvestOAuthApp");

this.webView2.Source = harvestClient.BuildAuthorizationUrl();
this.webView2.NavigationStarting += async (sender, args) =>
{
    if(!args.Uri.StartsWith(redirectUrl))
    {
        return;
    }

    if(credential.AccessToken == null || string.IsNullOrEmpty(credential.AccessToken.Token))
    {
        await this.client.AuthorizeAsync(new Uri(args.Uri));
    }
    else
    {
        // User is authorized and can make requests!
    }
}
```

## Personal Access Token

### .NET App (Console, Web API, etc.)

The following example shows how to authenticate a Web API using a personal access token.

```csharp
AuthCredential credential = new PATCredential("accessToken");
HarvestServiceClient harvestClient = new HarvestServiceClient(credential, "MyHarvestPATApp");

// User is authorized and can make requests!
```
