using System;
using System.Net;
using SnipeSharp.Exceptions;
using SnipeSharp.Models;
using Xunit;
using static SnipeSharp.Tests.Utility;

namespace SnipeSharp.Tests
{
    public sealed class StatusLabelEndPointTests
    {
        [Theory]
        [InlineData("0\n", false)]
        [InlineData("1\n", true)]
        public void IsDeployable_ReturnsBoolean(string response, bool expected)
        {
            var api = SingleUseApi(response);
            Assert.Equal(expected, api.StatusLabels.IsDeployable(new StatusLabel()));
        }

        [Fact]
        public void IsDeployable_CanFail()
        {
            var api = SingleUseApi("{\"status\":\"error\"}", isSuccessful: false, statusCode: HttpStatusCode.NotFound);
            Assert.Throws<ApiErrorException>(() => api.StatusLabels.IsDeployable(new StatusLabel()));
        }

        [Fact]
        public void IsDeployable_DoesNotAcceptNull()
        {
            Assert.Throws<ArgumentNullException>(() => SingleUseApi().StatusLabels.IsDeployable(null));
        }
    }
}
