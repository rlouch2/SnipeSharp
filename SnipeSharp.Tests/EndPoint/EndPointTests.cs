using Xunit;
using System;
using System.Net;
using SnipeSharp.Models;
using SnipeSharp.EndPoint;
using SnipeSharp.Exceptions;
using static SnipeSharp.Tests.Utility;
using SnipeSharp.Serialization;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace SnipeSharp.Tests
{
    [PathSegment(TestModel.PATH_SEGMENT)]
    internal sealed class TestModel : CommonEndPointModel, IEquatable<TestModel>
    {
        public const string PATH_SEGMENT = "test";

        internal TestModel(int id, string name, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id;
            Name = name;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [JsonConstructor]
        internal TestModel() { }

        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", IsRequired = true)]
        public override string Name { get; set; }

        [Field(DeserializeAs = "created_at", Converter = FieldConverter.DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field(DeserializeAs = "updated_at", Converter = FieldConverter.DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }

        public bool Equals([AllowNull] TestModel other)
        {
            if(null == other)
                return false;
            return Id == other.Id
                && Name == other.Name
                && CreatedAt == other.CreatedAt
                && UpdatedAt == other.UpdatedAt;
        }

        internal static TestModel Test1 { get; } = new TestModel(1, "Test1", new DateTime(2019, 12, 19, 12, 5, 0), null);
        internal static TestModel Test2 { get; } = new TestModel(2, "Test2", new DateTime(2019, 12, 19, 12, 6, 7), null);
    }

    internal sealed class FaultyTestModel : CommonEndPointModel
    {
        public override int Id { get; protected set; }
        public override string Name { get; set; }
        public override DateTime? CreatedAt { get; protected set; }
        public override DateTime? UpdatedAt { get; protected set; }
    }

    internal sealed class CustomEndPoint<T>: EndPoint<T>
        where T: CommonEndPointModel
    {
        internal CustomEndPoint(SnipeItApi api) : base(api) { }
        internal new PathSegmentAttribute EndPointInfo => base.EndPointInfo;
    }

    public sealed class EndPointTests
    {
        #region Construction
        [Fact]
        public void MissingPathSegmentAttribute_ThrowsException()
        {
            Assert.Throws<MissingRequiredAttributeException>(() => {
                var endPoint = new EndPoint<FaultyTestModel>(SingleUseApi());
            });
        }

        [Fact]
        public void HasPathSegmentAttribute_DoesNotThrowException()
        {
            var endPoint = new CustomEndPoint<TestModel>(SingleUseApi());
            Assert.NotNull(endPoint.EndPointInfo);
            Assert.Equal(TestModel.PATH_SEGMENT, endPoint.EndPointInfo.BaseUri);
        }
        #endregion

        #region Find
        private const string FIND_NONE = @"
        {
            ""total"": 0,
            ""rows"": []
        }
        ";

        private const string FIND_ERROR = @"
        {
            ""status"": ""error"",
            ""messages"": {
                ""general"": ""It doesn't work.""
            }
        }
        ";

        private const string FIND_ALL_TWO_ROWS = @"
        {
            ""total"": 2,
            ""rows"": [
                {
                    ""id"": 1,
                    ""name"": ""Test1"",
                    ""created_at"": {
                        ""datetime"": ""2019-12-19 12:05:00"",
                        ""formatted"": ""2019-12-19 12:05 PM""
                    }
                },
                {
                    ""id"": 2,
                    ""name"": ""Test2"",
                    ""created_at"": {
                        ""datetime"": ""2019-12-19 12:06:07"",
                        ""formatted"": ""2019-12-19 12:06 PM""
                    }
                }
            ]
        }
        ";

        [Fact]
        public void FindAll_None()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_NONE));
            var response = endPoint.FindAll();
            Assert.Empty(response);
            Assert.Equal<long>(0L, response.Total);
        }

        [Fact]
        public void FindAll_Two_NoFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAll();
            Assert.Equal<long>(2L, response.Total);
            Assert.Collection(response,
                a => a.Equals(TestModel.Test1),
                a => a.Equals(TestModel.Test2));
        }

        [Fact]
        public void FindAll_Two_StringFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAll("blah");
            Assert.Equal<long>(2L, response.Total);
            Assert.Collection(response,
                a => a.Equals(TestModel.Test1),
                a => a.Equals(TestModel.Test2));
        }

        [Fact]
        public void FindAllOptional_Two_StringFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAllOptional("blah");
            Assert.True(response.HasValue);
            Assert.Equal<long>(2L, response.Value.Total);
            Assert.Collection(response.Value,
                a => a.Equals(TestModel.Test1),
                a => a.Equals(TestModel.Test2));
        }

        [Fact]
        public void FindOne()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindOne("blah");
            Assert.Equal(TestModel.Test1, response);
        }

        [Fact]
        public void FindOne_Fail()
        {
            Assert.Throws<ApiErrorException>(() => {
                var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_NONE, isSuccessful: false));
                endPoint.FindOne("blah");
            });
        }

        [Fact]
        public void FindOneOptional_StringFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindOneOptional("blah");
            Assert.True(response.HasValue);
            Assert.Equal(response.Value, TestModel.Test1);
        }

        [Fact]
        public void FindOneOptional_Fail()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ERROR));
            var response = endPoint.FindOneOptional("blah");
            Assert.False(response.HasValue);
            Assert.IsType<ApiErrorException>(response.Exception);
        }
        #endregion

        #region Get
        private const string GET_EXAMPLE = @"
        {
            ""id"": 1,
            ""name"": ""Test1"",
            ""created_at"": {
                ""datetime"": ""2019-12-19 12:05:00"",
                ""formatted"": ""2019-12-19 12:05 PM""
            }
        }
        ";

        [Fact]
        public void GetAll()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_NONE));
            var response = endPoint.GetAll();
            Assert.Empty(response);
            Assert.Equal<long>(0L, response.Total);
        }

        [Fact]
        public void GetAllOptional()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_NONE));
            var response = endPoint.GetAllOptional();
            Assert.True(response.HasValue);
            Assert.Empty(response.Value);
            Assert.Equal<long>(0L, response.Value.Total);
        }

        [Fact]
        public void Get_ById()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(GET_EXAMPLE));
            var response = endPoint.Get(1);
            Assert.Equal(TestModel.Test1, response);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Get_ByName(bool isCaseSensitive)
        {
            // using FIND_ALL_TWO_ROWS because ByName does a search, not a lookup
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.Get("Test1", caseSensitive: isCaseSensitive);
            Assert.Equal(TestModel.Test1, response);
        }

        [Fact]
        public void GetOptional_ByName_Fail()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ERROR));
            var response = endPoint.GetOptional("Test1");
            Assert.False(response.HasValue);
            Assert.IsType<ApiErrorException>(response.Exception);
        }
        #endregion

        #region Create, Delete, Update
        #endregion

        [Fact]
        public void ErrorResponseThrowsException()
        {
            Assert.Throws<ApiErrorException>(() => {
               SingleUseApiFromFile("./Resources/error_no_status_label.json").StatusLabels.Get(0);
            });
        }

        [Fact]
        public void HttpErrorThrowsException()
        {
            Assert.Throws<ApiErrorException>(() => {
                SingleUseApiFromFile("./Resources/error_404.json", false, HttpStatusCode.NotFound).StatusLabels.Get(0);
            });
        }
    }
}
