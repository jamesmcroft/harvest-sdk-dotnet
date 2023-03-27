namespace Harvest.Common.Extensions;

using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Defines a collection of extension methods for <see cref="IDictionary{TKey,TValue}"/> objects.
/// </summary>
internal static class DictionaryExtensions
{
    /// <summary>
    /// Try to add the element to the <see cref="IDictionary"/> instance.
    /// </summary>
    /// <typeparam name="TKey"> The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary to add to.</param>
    /// <param name="key">The key parameter.</param>
    /// <param name="value">The value.</param>
    /// <returns><see langword="true"/> if the element was added; <see langword="false"/> if the element already exists.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="dictionary"/> or <paramref name="value"/> is <see langword="null"/>.</exception>
    public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary == null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }

        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (dictionary.ContainsKey(key))
        {
            return false;
        }

        dictionary.Add(key, value);
        return true;
    }

    /// <summary>
    /// Adds or replaces the element to the <see cref="IDictionary"/> instance.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="dictionary">The dictionary to add to.</param>
    /// <param name="key">The key parameter.</param>
    /// <param name="value">The value.</param>
    /// <returns>The previous value if any.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="dictionary"/> or <paramref name="key"/> is <see langword="null"/>.</exception>
    public static TValue AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (TryAdd(dictionary, key, value))
        {
            return default;
        }

        TValue previousValue = dictionary[key];
        dictionary[key] = value;
        return previousValue;
    }
}