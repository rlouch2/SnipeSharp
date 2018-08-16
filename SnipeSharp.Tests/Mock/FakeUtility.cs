using RestSharp;

namespace SnipeSharp.Tests.Mock
{
    internal class FakeUtility: SnipeSharp.Utility
    {
        internal override IRestClient NewRestClient()
            => RestClient;
        
        internal FakeRestClient RestClient { get; set; } = new FakeRestClient();
    }
}