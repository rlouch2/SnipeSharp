using System;
using SnipeSharp.PowerShell;
using Xunit;

namespace SnipeSharp.Tests.PowerShell
{
    public sealed class ConnectSnipeITTests: IDisposable
    {
        public ConnectSnipeITTests()
        {
            ApiHelper.Reset();
            Utility.ResetQueue();
        }
        public void Dispose()
        {
        }

        [Fact]
        public void NotConnectingFails()
        {
            Utility.QueueResponseFromFile("./Resources/error.html");
            var errors = PSAssert.PSHasErrorRecord(@"
                Connect-SnipeInstance -Uri 'http://not.exist.localhost/api/v1' -Token 'xxxx'
            ");
            Assert.NotEmpty(errors);
            Assert.False(ApiHelper.HasApiInstance);
        }

        [Fact]
        public void ConnectingSucceeds()
        {
            Utility.QueueResponseFromFile("./Resources/IndividualModels/user.json");
            var errors = PSAssert.PSHasErrorRecord(@"
                Connect-SnipeInstance -Uri 'http://not.exist.localhost/api/v1' -Token 'xxxx'
            ");
            Assert.Empty(errors);
            Assert.True(ApiHelper.HasApiInstance);
        }

        [Fact]
        public void ConnectingTwiceFails()
        {
            Utility.QueueResponseFromFile("./Resources/IndividualModels/user.json");
            var errors = PSAssert.PSHasErrorRecord(@"
                Connect-SnipeInstance -Uri 'http://not.exist.localhost/api/v1' -Token 'xxxx'
                Connect-SnipeInstance -Uri 'http://not.exist.localhost/api/v1' -Token 'xxxx'
            ");
            Assert.NotEmpty(errors);
            Assert.True(ApiHelper.HasApiInstance);
        }
    }
}
