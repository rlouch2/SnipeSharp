using System.Collections.Generic;
using SnipeSharp.Common;

namespace SnipeSharp.EndPoint.Filters
{
    public interface ISearchFilter : IQueryParameterProvider
    {
        int? Limit { get; set; }
        int? Offset { get; set; }
        string Search { get; set; }
        string Sort { get; set; }
        string Order { get; set; }
    }
}
