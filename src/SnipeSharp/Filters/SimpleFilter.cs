using System.Collections.Generic;

namespace SnipeSharp
{
    public sealed class SimpleFilter<T>: IFilter<T>
    {
        private const string LIMIT_NAME = "limit";
        private const string OFFSET_NAME = "offset";
        private const string SEARCH_NAME = "search";

        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? SearchString { get; set; }

        public IFilter<T> Clone() => new SimpleFilter<T>
        {
            Limit = Limit,
            Offset = Offset,
            SearchString = SearchString
        };

        public IReadOnlyDictionary<string, string?> GetParameters()
        {
            var parameters = new Dictionary<string, string?>();
            if(null != Limit)
                parameters[LIMIT_NAME] = Limit.ToString();
            if(null != Offset)
                parameters[OFFSET_NAME] = Offset.ToString();
            if(null != SearchString)
                parameters[SEARCH_NAME] = Offset.ToString();
            return parameters;
        }
    }
}
