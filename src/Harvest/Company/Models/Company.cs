namespace Harvest.Company.Models;

using Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for a company.
/// </summary>
public class Company
{
    /// <summary>
    /// Gets or sets the Harvest URL for the company.
    /// </summary>
    [JsonProperty("base_uri")]
    public string BaseUri { get; set; }

    /// <summary>
    /// Gets or sets the Harvest domain for the company.
    /// </summary>
    [JsonProperty("full_domain")]
    public string FullDomain { get; set; }

    /// <summary>
    /// Gets or sets the name of the company.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the company is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the week day used as the start of the week.
    /// </summary>
    [JsonProperty("week_start_day")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public WeekStartDay WeekStartDay { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether time is tracked via durations or start and end times.
    /// </summary>
    [JsonProperty("wants_timestamp_timers")]
    public bool? WantsTimestampTimers { get; set; }

    /// <summary>
    /// Gets or sets the format used to display time in Harvest.
    /// </summary>
    [JsonProperty("time_format")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public TimeFormat TimeFormat { get; set; }

    /// <summary>
    /// Gets or sets the format used to display date in Harvest.
    /// </summary>
    [JsonProperty("date_format")]
    public string DateFormat { get; set; }

    /// <summary>
    /// Gets or sets the type of plan the company is on.
    /// </summary>
    [JsonProperty("plan_type")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public PlanType PlanType { get; set; }

    /// <summary>
    /// Gets or sets the representation for whether the clock is 12 or 24 hour.
    /// </summary>
    [JsonProperty("clock")]
    public string Clock { get; set; }

    /// <summary>
    /// Gets or sets how to display the currency code when formatting currency.
    /// </summary>
    [JsonProperty("currency_code_display")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public CurrencyCodeDisplay CurrencyCodeDisplay { get; set; }

    /// <summary>
    /// Gets or sets how to display the currency symbol when formatting currency.
    /// </summary>
    [JsonProperty("currency_symbol_display")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public CurrencySymbolDisplay CurrencySymbolDisplay { get; set; }

    /// <summary>
    /// Gets or sets the symbol used when formatting decimals.
    /// </summary>
    [JsonProperty("decimal_symbol")]
    public string DecimalSymbol { get; set; }

    /// <summary>
    /// Gets or sets the separator used when formatting numbers.
    /// </summary>
    [JsonProperty("thousands_separator")]
    public string ThousandsSeparator { get; set; }

    /// <summary>
    /// Gets or sets the color scheme being used in the Harvest web client.
    /// </summary>
    [JsonProperty("color_scheme")]
    public string ColorScheme { get; set; }

    /// <summary>
    /// Gets or sets the weekly capacity in seconds.
    /// </summary>
    [JsonProperty("weekly_capacity")]
    public int? WeeklyCapacity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the expense module is enabled.
    /// </summary>
    [JsonProperty("expense_feature")]
    public bool? ExpenseFeature { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the invoice module is enabled.
    /// </summary>
    [JsonProperty("invoice_feature")]
    public bool? InvoiceFeature { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the estimate module is enabled.
    /// </summary>
    [JsonProperty("estimate_feature")]
    public bool? EstimateFeature { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the approval module is enabled.
    /// </summary>
    [JsonProperty("approval_feature")]
    public bool? ApprovalFeature { get; set; }
}