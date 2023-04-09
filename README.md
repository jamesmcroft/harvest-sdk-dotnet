# Harvest Time Tracking .NET Client Library

[![GitHub Actions][badge_actions]][link_actions]
[![GitHub Issues][badge_issues]][link_issues]
[![GitHub Stars][badge_repo_stars]][link_repo]
[![Repo Language][badge_language]][link_repo]
[![Repo License][badge_license]][link_repo]
[![GitHub Sponsor][badge_sponsor]][link_sponsor]

Integrate the [Harvest Time Tracking API](https://help.getharvest.com/api-v2/) into your .NET application!

## Installation

To install the Harvest .NET SDK:

- Search for `Harvest.Sdk` in a NuGet package manager, or
- Type `Install-Package Harvest.Sdk` in the NuGet Package Manager Console

## Getting started

### 1. Register your application

To use the Harvest API, you must first register your application. This will provide you with a **Client ID** and **Client Secret** that you can use to authenticate your application.

To register your application, visit the [Harvest Developer Portal](https://id.getharvest.com/developers) and click either the **Create new OAuth2 application** or **Create new personal access token** buttons.

### 2. Create a Harvest client object with an authentication method

An instance of the `HarvestServiceClient` class handles building requests, sending them to the Harvest API, and processing the responses. To Create a new instance of this class, you need to provide an instance of `AuthCredential` which contains your OAuth2 or PAT credentials to authenticate requests to the Harvest API.

For more information on initializing a client instance, see the [Getting Started](docs/readme.md) documentation.

### 3. Make requests to the Harvest API

Once you have completed authentication and have a `HarvestServiceClient` instance, you can make requests to the Harvest API. The requests in the SDK follow a similar format of the Harvest API's syntax.

For example, to retrieve a list of all projects, you can use the following code:

```csharp
var projects = await harvestClient.Projects.GetAsync();
```

`GetAsync` will return a `ProjectsResponse` object on success which contains a list of `Project` objects.

For more information on making requests to the Harvest API, see the [Getting Started](docs/readme.md) documentation.

## Documentation and resources

- [Getting Started](docs/readme.md)
- [Harvest API Documentation](https://help.getharvest.com/api-v2/)
- [Release Notes](https://github.com/jamesmcroft/harvest-sdk-dotnet/releases)
- [NuGet Package](https://www.nuget.org/packages/Harvest.Sdk/)

## Issues and contributions

Take a look through our [contribution guidelines](CONTRIBUTING.md). We actively encourage you to jump in and help with any issues!

To view or log issues, visit the [GitHub Issues](https://github.com/jamesmcroft/harvest-sdk-dotnet/issues) page.

## Building locally

The Harvest .NET SDK is built using .NET Standard.

You will need the following installed on your machine:

- Have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- Run `dotnet restore` to restore the project dependencies.
- Run `dotnet build` to build the project.

You can also use Visual Studio with appropriate workloads installed to build the project.

## Supporting this project

As many developers know, projects like this are built in spare time! If you find this project useful, please **Star** the repo.

## Author

👤 James Croft

[![Website][badge_blog]][link_blog]
[![Twitter][badge_twitter]][link_twitter]
[![LinkedIn][badge_linkedin]][link_linkedin]

## License

The Harvest .NET SDK is made available under the terms and conditions of the [MIT license](LICENSE).

[badge_blog]: https://img.shields.io/badge/blog-jamesmcroft.co.uk-blue?style=for-the-badge
[badge_linkedin]: https://img.shields.io/badge/LinkedIn-jmcroft-blue?style=for-the-badge&logo=linkedin
[badge_twitter]: https://img.shields.io/badge/follow-%40jamesmcroft-1DA1F2?logo=twitter&style=for-the-badge&logoColor=white
[link_blog]: https://www.jamescroft.co.uk/
[link_linkedin]: https://www.linkedin.com/in/jmcroft
[link_twitter]: https://twitter.com/jamesmcroft
[badge_language]: https://img.shields.io/badge/language-C%23-blue?style=for-the-badge
[badge_license]: https://img.shields.io/github/license/jamesmcroft/harvest-sdk-dotnet?style=for-the-badge
[badge_issues]: https://img.shields.io/github/issues/jamesmcroft/harvest-sdk-dotnet?style=for-the-badge
[badge_repo_stars]: https://img.shields.io/github/stars/jamesmcroft/harvest-sdk-dotnet?logo=github&style=for-the-badge
[badge_sponsor]: https://img.shields.io/github/sponsors/jamesmcroft?logo=github&style=for-the-badge
[link_issues]: https://github.com/jamesmcroft/harvest-sdk-dotnet/issues
[link_repo]: https://github.com/jamesmcroft/harvest-sdk-dotnet
[link_sponsor]: https://github.com/sponsors/jamesmcroft
[badge_actions]: https://img.shields.io/github/actions/workflow/status/jamesmcroft/harvest-sdk-dotnet/ci.yml?style=for-the-badge
[link_actions]: https://github.com/jamesmcroft/harvest-sdk-dotnet
