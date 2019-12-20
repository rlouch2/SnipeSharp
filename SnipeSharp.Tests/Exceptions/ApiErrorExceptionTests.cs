using SnipeSharp.Exceptions;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace SnipeSharp.Tests
{
    public sealed class ApiErrorExceptionTests
    {
        const string TEST_MESSAGE = "Test";

        /// A message longer than 80 characters
        const string LONG_TEST_MESSAGE = "00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27";

        [Fact]
        public void ConstructWith_StatusCode()
        {
            var ex = new ApiErrorException(HttpStatusCode.Forbidden, null);
            Assert.True(ex.IsHttpError);
            Assert.Equal(HttpStatusCode.Forbidden, ex.HttpStatusCode);
            Assert.Equal(HttpStatusCode.Forbidden.ToString(), ex.Message);
        }

        [Fact]
        public void ConstructWith_StatusCodeAndMessage()
        {
            var ex = new ApiErrorException(HttpStatusCode.Forbidden, TEST_MESSAGE);
            Assert.True(ex.IsHttpError);
            Assert.Equal(HttpStatusCode.Forbidden, ex.HttpStatusCode);
            Assert.Equal(TEST_MESSAGE, ex.Message);
        }

        [Fact]
        public void ConstructWith_Message()
        {
            var ex = new ApiErrorException(TEST_MESSAGE);
            Assert.False(ex.IsHttpError);
            Assert.Null(ex.HttpStatusCode);
            Assert.Equal(TEST_MESSAGE, ex.Message);
        }

        [Fact]
        public void ConstructWith_Dictionary()
        {
            var ex = new ApiErrorException(new Dictionary<string, string> { ["Key1"] = "Value1", ["Key2"] = "Value2" });
            Assert.False(ex.IsHttpError);
            Assert.Null(ex.HttpStatusCode);
            Assert.NotNull(ex.Messages);
            Assert.Equal(@"{""Key1"":""Value1"", ""Key2"":""Value2""}", ex.Message);
        }

        [Theory]
        [InlineData(TEST_MESSAGE)]
        [InlineData(LONG_TEST_MESSAGE)]
        public void ToString_NotAnHttpError_DoesNotTruncate(string message)
        {
            var ex = new ApiErrorException(message);
            Assert.False(ex.IsHttpError);
            Assert.Equal($"SnipeSharp.Exceptions.ApiErrorException: {message}", ex.ToString());
        }

        [Fact]
        public void ToString_HttpError()
        {
            var ex = new ApiErrorException(HttpStatusCode.Forbidden, TEST_MESSAGE);
            Assert.True(ex.IsHttpError);
            Assert.Equal($"{HttpStatusCode.Forbidden}: {TEST_MESSAGE}", ex.ToString());
        }

        [Fact]
        public void ToString_HttpError_TruncatesLongMessages()
        {
            var ex = new ApiErrorException(HttpStatusCode.Forbidden, LONG_TEST_MESSAGE);
            Assert.True(ex.IsHttpError);
            Assert.Equal($"{HttpStatusCode.Forbidden}: {LONG_TEST_MESSAGE.Substring(0, 77)}...", ex.ToString());
        }
    }
}
