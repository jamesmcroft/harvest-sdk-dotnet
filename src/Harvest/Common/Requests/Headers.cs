namespace Harvest.Common.Requests;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Defines a collection of HTTP headers.
/// </summary>
public class Headers : IDictionary<string, IEnumerable<string>>
{
    private readonly Dictionary<string, HashSet<string>> headers = new(StringComparer.OrdinalIgnoreCase);

    /// <inheritdoc/>
    public ICollection<string> Keys => this.headers.Keys;

    /// <inheritdoc/>
    public ICollection<IEnumerable<string>> Values => this.headers.Values.Cast<IEnumerable<string>>().ToList();

    /// <inheritdoc/>
    public int Count => this.headers.Count;

    /// <inheritdoc/>
    public bool IsReadOnly => false;

    /// <inheritdoc/>
    public IEnumerable<string> this[string key]
    {
        get => this.TryGetValue(key, out IEnumerable<string> result)
            ? result
            : throw new KeyNotFoundException($"Key not found : {key}");
        set => this.Add(key, value);
    }

    /// <summary>
    /// Adds values to the header with the specified name.
    /// </summary>
    /// <param name="headerName">The name of the header to add values to.</param>
    /// <param name="headerValues">The values to add to the header.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="headerName"/> or <paramref name="headerValues"/> is <see langword="null"/>.</exception>
    public void Add(string headerName, params string[] headerValues)
    {
        if (string.IsNullOrEmpty(headerName))
        {
            throw new ArgumentNullException(nameof(headerName));
        }

        if (headerValues == null)
        {
            throw new ArgumentNullException(nameof(headerValues));
        }

        if (!headerValues.Any())
        {
            return;
        }

        if (this.headers.TryGetValue(headerName, out HashSet<string> values))
        {
            foreach (string headerValue in headerValues)
            {
                values.Add(headerValue);
            }
        }
        else
        {
            this.headers.Add(headerName, new HashSet<string>(headerValues));
        }
    }

    /// <summary>
    /// Removes the specified value from the header with the specified name.
    /// </summary>
    /// <param name="headerName">The name of the header to remove the value from.</param>
    /// <param name="headerValue">The value to remove from the header.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="headerName"/> or <paramref name="headerValue"/> is <see langword="null"/>.</exception>
    public bool Remove(string headerName, string headerValue)
    {
        if (string.IsNullOrEmpty(headerName))
        {
            throw new ArgumentNullException(nameof(headerName));
        }

        if (headerValue == null)
        {
            throw new ArgumentNullException(nameof(headerValue));
        }

        if (!this.headers.TryGetValue(headerName, out HashSet<string> values))
        {
            return false;
        }

        bool result = values.Remove(headerValue);
        if (!values.Any())
        {
            this.headers.Remove(headerName);
        }

        return result;
    }

    /// <summary>
    /// Adds all the headers values from the specified headers collection.
    /// </summary>
    /// <param name="allHeaders">The headers to update the current headers with.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="allHeaders"/> is <see langword="null"/>.</exception>
    public void AddAll(Headers allHeaders)
    {
        if (allHeaders == null)
        {
            throw new ArgumentNullException(nameof(allHeaders));
        }

        foreach (KeyValuePair<string, IEnumerable<string>> header in allHeaders)
        {
            foreach (string value in header.Value)
            {
                this.Add(header.Key, value);
            }
        }
    }

    /// <summary>
    /// Removes all headers.
    /// </summary>
    public void Clear()
    {
        this.headers.Clear();
    }

    /// <inheritdoc/>
    public bool ContainsKey(string key)
    {
        return !string.IsNullOrEmpty(key) && this.headers.ContainsKey(key);
    }

    /// <inheritdoc/>
    public void Add(string key, IEnumerable<string> value)
    {
        this.Add(key, value?.ToArray());
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="key"/> is <see langword="null"/>.</exception>
    public bool Remove(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        return this.headers.Remove(key);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="key"/> is <see langword="null"/>.</exception>
    public bool TryGetValue(string key, out IEnumerable<string> value)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (this.headers.TryGetValue(key, out HashSet<string> values))
        {
            value = values;
            return true;
        }

        value = Enumerable.Empty<string>();
        return false;
    }

    /// <inheritdoc/>
    public void Add(KeyValuePair<string, IEnumerable<string>> item)
    {
        this.Add(item.Key, item.Value);
    }

    /// <inheritdoc/>
    public bool Contains(KeyValuePair<string, IEnumerable<string>> item)
    {
        return this.TryGetValue(item.Key, out IEnumerable<string> values) && item.Value.All(x => values.Contains(x)) &&
               values.Count() == item.Value.Count();
    }

    /// <summary>
    /// This method is not implemented.
    /// </summary>
    /// <exception cref="NotImplementedException">Thrown as this method is not implemented.</exception>
    public void CopyTo(KeyValuePair<string, IEnumerable<string>>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool Remove(KeyValuePair<string, IEnumerable<string>> item)
    {
        return item.Value.Aggregate(false, (current, value) => current | this.Remove(item.Key, value));
    }

    /// <inheritdoc/>
    public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
    {
        return new RequestHeadersEnumerator(this.headers.GetEnumerator());
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private sealed class RequestHeadersEnumerator : IEnumerator<KeyValuePair<string, IEnumerable<string>>>
    {
        private readonly IEnumerator enumerator;

        public RequestHeadersEnumerator(IEnumerator enumerator)
        {
            this.enumerator = enumerator;
        }

        public KeyValuePair<string, IEnumerable<string>> Current =>
            this.enumerator.Current is KeyValuePair<string, HashSet<string>> current
                ? new(current.Key, current.Value)
                : throw new InvalidOperationException();

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            (this.enumerator as IDisposable)?.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            return this.enumerator.MoveNext();
        }

        public void Reset()
        {
            this.enumerator.Reset();
        }
    }
}