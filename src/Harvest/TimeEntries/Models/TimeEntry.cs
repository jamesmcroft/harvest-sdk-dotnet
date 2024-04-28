namespace Harvest.TimeEntries.Models;

using System;
using Common.Serialization;
using Harvest.Clients.Models;
using Harvest.Common.Responses;
using Harvest.Invoices.Models;
using Harvest.Projects.Models;
using Harvest.Projects.TaskAssignments.Models;
using Harvest.Projects.UserAssignments.Models;
using Harvest.Tasks.Models;
using Harvest.Users.Models;
using Newtonsoft.Json;

/// <summary>
/// Defines the details for a time entry.
/// </summary>
public class TimeEntry : Entry
{
    /// <summary>
    /// Gets or sets the date of the time entry.
    /// </summary>
    [JsonProperty("spent_date")]
    public DateTime? SpentDate { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the time entry.
    /// </summary>
    [JsonProperty("user")]
    public UserSummary User { get; set; }

    /// <summary>
    /// Gets or sets the user assignment associated with the time entry.
    /// </summary>
    [JsonProperty("user_assignment")]
    public UserAssignment UserAssignment { get; set; }

    /// <summary>
    /// Gets or sets the client associated with the time entry.
    /// </summary>
    [JsonProperty("client")]
    public ClientSummary Client { get; set; }

    /// <summary>
    /// Gets or sets the project associated with the time entry.
    /// </summary>
    [JsonProperty("project")]
    public ProjectSummary Project { get; set; }

    /// <summary>
    /// Gets or sets the task associated with the time entry.
    /// </summary>
    [JsonProperty("task")]
    public TaskSummary Task { get; set; }

    /// <summary>
    /// Gets or sets the task assignment associated with the time entry.
    /// </summary>
    [JsonProperty("task_assignment")]
    public TaskAssignment TaskAssignment { get; set; }

    /// <summary>
    /// Gets or sets the ID, group ID, account ID, permalink, service, or service icon URL of the associated external reference.
    /// </summary>
    [JsonProperty("external_reference")]
    public string ExternalReference { get; set; }

    /// <summary>
    /// Gets or sets the invoice associated with the time entry.
    /// </summary>
    [JsonProperty("invoice")]
    public InvoiceSummary Invoice { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal hours tracked in this time entry.
    /// </summary>
    [JsonProperty("hours")]
    public decimal? Hours { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal hours tracked in this time entry before the timer was last started.
    /// </summary>
    [JsonProperty("hours_without_timer")]
    public decimal? HoursWithoutTimer { get; set; }

    /// <summary>
    /// Gets or sets the number of decimal hours tracked in this time entry used in summary reports and invoices.
    /// </summary>
    [JsonProperty("rounded_hours")]
    public decimal? RoundedHours { get; set; }

    /// <summary>
    /// Gets or sets the notes attached to the time entry.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the time entry is locked.
    /// </summary>
    [JsonProperty("is_locked")]
    public bool? IsLocked { get; set; }

    /// <summary>
    /// Gets or sets the reason why the time entry is locked.
    /// </summary>
    [JsonProperty("locked_reason")]
    public string LockedReason { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the time entry has been approved via Timesheet Approval.
    /// </summary>
    [JsonProperty("is_closed")]
    public bool? IsClosed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the time entry has been marked as invoiced.
    /// </summary>
    [JsonProperty("is_billed")]
    public bool? IsBilled { get; set; }

    /// <summary>
    /// Gets or sets the date and time the timer was started if tracking by duration.
    /// </summary>
    [JsonProperty("timer_started_at")]
    public DateTime? TimerStartedAt { get; set; }

    /// <summary>
    /// Gets or sets the time that the time entry was started if tracking by start/end times.
    /// </summary>
    [JsonProperty("started_time")]
    [JsonConverter(typeof(HarvestTimeValueConverter))]
    public TimeSpan? StartedTime { get; set; }

    /// <summary>
    /// Gets or sets the time that the time entry was ended if tracking by start/end times.
    /// </summary>
    [JsonProperty("ended_time")]
    [JsonConverter(typeof(HarvestTimeValueConverter))]
    public TimeSpan? EndedTime { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the time entry is currently running.
    /// </summary>
    [JsonProperty("is_running")]
    public bool? IsRunning { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the time entry is billable.
    /// </summary>
    [JsonProperty("billable")]
    public bool? Billable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the time entry counts towards the project budget.
    /// </summary>
    [JsonProperty("budgeted")]
    public bool? Budgeted { get; set; }

    /// <summary>
    /// Gets or sets the billable rate for the time entry.
    /// </summary>
    [JsonProperty("billable_rate")]
    public decimal? BillableRate { get; set; }

    /// <summary>
    /// Gets or sets the cost rate for the time entry.
    /// </summary>
    [JsonProperty("cost_rate")]
    public decimal? CostRate { get; set; }
}