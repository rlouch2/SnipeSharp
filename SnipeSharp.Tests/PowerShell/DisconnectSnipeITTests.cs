using System;
using SnipeSharp.PowerShell;
using Xunit;

namespace SnipeSharp.Tests.PowerShell
{
    public sealed class DisconnectSnipeITTests: IDisposable
    {
        public DisconnectSnipeITTests()
        {
            ApiHelper.Reset();
            Utility.ResetQueue();
        }
        public void Dispose()
        {
        }

        [Fact]
        public void CanDisconnectWhenNotConnected()
        {
            var errors = PSAssert.PSHasErrorRecord(@"
                Disconnect-SnipeIT
            ");
            Assert.Empty(errors);
            Assert.False(ApiHelper.HasApiInstance);
        }

        [Fact]
        public void CanDisconnectWhenConnected()
        {
            Utility.QueueResponseFromFile("./Resources/IndividualModels/user.json");
            var errors = PSAssert.PSHasErrorRecord(@"
                Connect-SnipeIT -Uri 'http://not.exist.localhost/api/v1' -Token 'xxxx'
                Disconnect-SnipeIT
            ");
            Assert.Empty(errors);
            Assert.False(ApiHelper.HasApiInstance);
        }
    }
}
