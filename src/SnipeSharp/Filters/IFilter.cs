using System.Collections.Generic;

namespace SnipeSharp
{
    public interface IFilter<T>
    {
        int? Limit { get; set; }
        int? Offset { get; set; }

        IReadOnlyDictionary<string, string?> GetParameters();
        IFilter<T> Clone();
    }
}
