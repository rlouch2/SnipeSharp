using System.Collections.Generic;
using SnipeSharp.EndPoint.Models;
using SnipeSharp.Serialization;

namespace SnipeSharp.EndPoint.Filters
{
    public sealed class SearchFilter : ISearchFilter<string>
    {
        [Field("limit", true)]
        public int? Limit { get; set; }

        [Field("offset", true)]
        public int? Offset { get; set; }

        [Field("search", true)]
        public string Search { get; set; }

        [Field("sort", true)]
        public string SortColumn { get; set; }

        [Field("order", true)]
        public SearchOrder Order { get; set; }
        public SearchFilter()
        {
        }

        public SearchFilter(string searchString)
        {
            Search = searchString;
        }
    }
}
