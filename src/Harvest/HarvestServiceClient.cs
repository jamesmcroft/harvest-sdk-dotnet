namespace Harvest;

using System;
using System.Collections.Generic;
using Authentication;
using Clients;
using Common.Extensions;
using Common.Requests;
using Company;
using Contacts;
using Projects;
using Reports;
using Roles;
using Tasks;
using TimeEntries;
using UserAssignments;
using Users;

/// <summary>
/// Defines the client used to communicate with the Harvest API.
/// </summary>
public partial class HarvestServiceClient
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HarvestServiceClient"/> class with the specified authentication credential.
    /// </summary>
    /// <param name="authCredential">The authentication credential used to authenticate the client.</param>
    public HarvestServiceClient(AuthCredential authCredential) : this(new HarvestRequestAdapter(authCredential))
    {
        this.authCredential = authCredential;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HarvestServiceClient"/> class with the specified request adapter.
    /// </summary>
    /// <param name="requestAdapter">The request adapter for sending requests.</param>
    public HarvestServiceClient(HarvestRequestAdapter requestAdapter)
    {
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
        this.PathParameters = new Dictionary<string, object>();
        this.UrlTemplate = "{+baseurl}";
        this.RequestAdapter = requestAdapter;
        this.authCredential = this.RequestAdapter.Credential;
        this.RequestAdapter.BaseUrl = "https://api.harvestapp.com/v2";
        this.PathParameters.TryAdd("baseurl", this.RequestAdapter.BaseUrl);
    }

    /// <summary>
    /// Gets the builder for operations to manage clients.
    /// </summary>
    public ClientsRequestBuilder Clients => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage the company.
    /// </summary>
    public CompanyRequestBuilder Company => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage client contacts.
    /// </summary>
    public ContactsRequestBuilder Contacts => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage projects.
    /// </summary>
    public ProjectsRequestBuilder Projects => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage reports.
    /// </summary>
    public ReportsRequestBuilder Reports => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage roles.
    /// </summary>
    public RolesRequestBuilder Roles => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage tasks.
    /// </summary>
    public TasksRequestBuilder Tasks => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage time entries.
    /// </summary>
    public TimeEntriesRequestBuilder TimeEntries => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage users.
    /// </summary>
    public UsersRequestBuilder Users => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manager user assignments.
    /// </summary>
    public UserAssignmentsRequestBuilder UserAssignments => new(this.PathParameters, this.RequestAdapter);

    private HarvestRequestAdapter RequestAdapter { get; }

    private Dictionary<string, object> PathParameters { get; }

    private string UrlTemplate { get; }
}