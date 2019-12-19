using SnipeSharp.Models;
using Xunit;
using static SnipeSharp.Tests.Utility;

namespace SnipeSharp.Tests
{
    public sealed class StatusLabelEndPointTests
    {
        [Theory]
        [InlineData("./Resources/get_raw_0.json", false)]
        [InlineData("./Resources/get_raw_1.json", true)]
        public void GetRawReturnsBoolean(string filename, bool expected)
        {
            var api = SingleUseApiFromFile(filename);
            Assert.Equal(expected, api.StatusLabels.IsDeployable(new StatusLabel()));
        }
    }
}
