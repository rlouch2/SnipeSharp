using SnipeSharp.Models;
using static SnipeSharp.Test.Utility;
using Xunit;
using System;

namespace SnipeSharp.Test
{
    public sealed class SnipeItApiTest
    {
        [Fact]
        public void TestConnection_Successful()
        {
            var snipe = new SnipeItApi(TEST_URI, TEST_TOKEN);
            Assert.True(snipe.TestConnection().Result);
        }

        [Fact]
        public void TestConnection_BadUri_Fails()
        {
            var snipe = new SnipeItApi(new Uri("http://fake.localhost"), TEST_TOKEN);
            Assert.False(snipe.TestConnection().Result);
        }

        [Fact]
        public void TestConnection_BadToken_Fails()
        {
            var snipe = new SnipeItApi(TEST_URI, string.Empty);
            Assert.False(snipe.TestConnection().Result);
        }

        public static async void Test()
        {
            var snipe = new SnipeItApi(TEST_URI, TEST_TOKEN);
            var mainSite = await snipe.Locations.GetAsync(1);
            await foreach(var site in mainSite!.ChildLocations.ResolveAsync<Location>(snipe))
                Console.WriteLine(site?.Name);
        }
    }
}
