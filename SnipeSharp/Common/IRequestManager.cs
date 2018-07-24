using SnipeSharp.Endpoints.Models;
using SnipeSharp.Endpoints.SearchFilters;

namespace SnipeSharp.Common
{
    public interface IRequestManager
    {
        // TODO: Implement bad return status handling in implementations of this
        string Put(string path, ICommonEndpointModel item);
        string Get(string path);
        string Get(string path, ISearchFilter filter);
        string Post(string path, ICommonEndpointModel item);
        string Delete(string path);
        void CheckApiTokenAndUrl();
    }
}
