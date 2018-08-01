using System.Collections.Generic;

namespace SnipeSharp.EndPoint.Filters
{
    public interface IInternalSearchFilter
    {
        int? Limit { get; set; }
        int? Offset { get; set; }
        string Search { get; set; }
        SearchOrder Order { get; set; }
    }
    public interface ISearchFilter<T>: IInternalSearchFilter
    {
        T SortColumn { get; set; }
    }
}
