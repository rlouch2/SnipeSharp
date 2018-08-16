using RestSharp;

namespace SnipeSharp
{
    internal class Utility
    {
        internal static Utility Instance { get; set; } = new Utility();

        internal virtual IRestClient NewRestClient()
            => new RestClient();
    }
}