using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;

namespace SnipeSharp.Common
{
    public interface IRequestManager
    {
        // TODO: Implement bad return status handling in implementations of this
        string Put(string path, IQueryParameterProvider item);
        string Get(string path);
        string Get(string path, IQueryParameterProvider filter);
        string Post(string path, IQueryParameterProvider item);
        string Delete(string path);
        void CheckApiTokenAndUrl();
    }
}
