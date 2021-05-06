using System.Collections.Generic;

namespace SnipeSharp
{
    internal sealed class BasicFilter<T> : IFilter<T>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }

        // don't actually clone basic filters; they're used exclusively as a fallback mechanism.
        public IFilter<T> Clone() => this;

        public IReadOnlyDictionary<string, string?> GetParameters()
            => new Dictionary<string, string?>()
                .AddIfNotNull(Static.LIMIT, Limit?.ToString())
                .AddIfNotNull(Static.OFFSET, Offset?.ToString());
    }
}
