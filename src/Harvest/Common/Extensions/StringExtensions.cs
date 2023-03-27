namespace Harvest.Common.Extensions;

/// <summary>
/// Defines a collection of extension methods for <see cref="string"/> values.
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Returns a string with the first letter lowered.
    /// </summary>
    /// <param name="input">The string to lowercase.</param>
    /// <returns>The input string with the first letter lowered.</returns>
    public static string ToFirstCharacterLowerCase(this string input)
    {
        return string.IsNullOrEmpty(input) ? input : $"{char.ToLowerInvariant(input![0])}{input.Substring(1)}";
    }
}