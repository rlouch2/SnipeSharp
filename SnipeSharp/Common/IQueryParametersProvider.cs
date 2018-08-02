using System.Collections.Generic;

namespace SnipeSharp.Common
{
    public interface IQueryParameterProvider
    {
        Dictionary<string, string> QueryParameters { get; }
    }
}
