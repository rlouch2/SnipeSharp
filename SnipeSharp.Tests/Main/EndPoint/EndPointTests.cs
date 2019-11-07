using Xunit;
using System.IO;
using System.Net;
using SnipeSharp.Models;
using SnipeSharp.EndPoint;
using SnipeSharp.Exceptions;
using SnipeSharp.Tests.Mock;

namespace SnipeSharp.Tests.Main.EndPoint
{
    public sealed class EndPointTests
    {
        [Fact]
        public void ThrowsIfNoPathSegmentAttribute()
        {
            Assert.Throws<MissingRequiredAttributeException>(() => {
                var endPoint = new EndPoint<FaultyTestModel>(Utility.OneUseApi());
            });
        }

        [Fact]
        public void ErrorResponseThrowsException()
        {
            Assert.Throws<ApiErrorException>(() => {
               Utility.OneUseApi("./Resources/error_no_status_label.json").StatusLabels.Get(0);
            });
        }

        [Fact]
        public void HttpErrorThrowsException()
        {
            Assert.Throws<ApiErrorException>(() => {
                Utility.OneUseApi("./Resources/error_404.json", false, HttpStatusCode.NotFound).StatusLabels.Get(0);
            });
        }

        [Theory]
        [InlineData("./Resources/get_raw_0.json", false)]
        [InlineData("./Resources/get_raw_1.json", true)]
        public void GetRawReturnsBoolean(string filename, bool expected)
        {
            var api = Utility.OneUseApi(filename);
            Assert.Equal(expected, api.StatusLabels.IsDeployable(new StatusLabel()));
        }
    }
}
