namespace Harvest.ExpenseCategories.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an expense category.
/// </summary>
public class CreateExpenseCategory
{
    /// <summary>
    /// Gets or sets the name of the expense category.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the unit name of the expense category.
    /// </summary>
    [JsonProperty("unit_name")]
    public string UnitName { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the expense category.
    /// </summary>
    [JsonProperty("unit_price")]
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the expense category is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }
}