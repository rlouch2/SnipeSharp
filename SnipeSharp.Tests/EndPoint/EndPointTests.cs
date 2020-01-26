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
using System.Collections.Generic;
using SnipeSharp.Filters;

namespace SnipeSharp.Tests
{
    [PathSegment(TestModel.PATH_SEGMENT)]
    internal sealed class TestModel : AbstractBaseModel, IEquatable<TestModel>
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

        [DeserializeAs("name")]
        [SerializeAs("name", IsRequired = true)]
        public override string Name { get; set; }

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

    internal sealed class FaultyTestModel : AbstractBaseModel
    {
    }

    internal sealed class CustomEndPoint<T>: EndPoint<T>
        where T: AbstractBaseModel
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

        private const string TEST1_STRING = @"
        {
            ""id"": 1,
            ""name"": ""Test1"",
            ""created_at"": {
                ""datetime"": ""2019-12-19 12:05:00"",
                ""formatted"": ""2019-12-19 12:05 PM""
            }
        }";

        private const string TEST2_STRING = @"
        {
            ""id"": 2,
            ""name"": ""Test2"",
            ""created_at"": {
                ""datetime"": ""2019-12-19 12:06:07"",
                ""formatted"": ""2019-12-19 12:06 PM""
            }
        }
        ";

        private static readonly string FIND_ALL_TWO_ROWS = $@"
        {{
            ""total"": 2,
            ""rows"": [ {TEST1_STRING}, {TEST2_STRING} ]
        }}
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
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
        }

        [Fact]
        public void FindAll_Two_StringFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAll("blah");
            Assert.Equal<long>(2L, response.Total);
            Assert.Collection(response,
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
        }

        [Fact]
        public void FindAll_DoesNotAcceptNullString()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi());
            Assert.Throws<ArgumentNullException>(() => endPoint.FindAll(null as string));
        }

        [Fact]
        public void FindAll_DoesAcceptNullFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAll(null as ISearchFilter);
            Assert.Equal<long>(2L, response.Total);
            Assert.Collection(response,
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
        }

        [Fact]
        public void FindAllOptional_Two_StringFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAllOptional("blah");
            Assert.True(response.HasValue);
            Assert.Equal<long>(2L, response.Value.Total);
            Assert.Collection(response.Value,
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
        }

        [Fact]
        public void FindAllOptional_DoesNotAcceptNullString()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi());
            Assert.Throws<ArgumentNullException>(() => endPoint.FindAllOptional(null as string));
        }

        [Fact]
        public void FindAllOptional_DoesAcceptNullFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindAllOptional(null as ISearchFilter);
            Assert.True(response.HasValue);
            Assert.Equal<long>(2L, response.Value.Total);
            Assert.Collection(response.Value,
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
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
        public void FindOne_DoesNotAcceptNullString()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi());
            Assert.Throws<ArgumentNullException>(() => endPoint.FindOne(null as string));
        }

        [Fact]
        public void FindOne_DoesAcceptNullFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindOne(null as ISearchFilter);
            Assert.Equal(TestModel.Test1, response);
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

        [Fact]
        public void FindOneOptional_DoesNotAcceptNullString()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi());
            Assert.Throws<ArgumentNullException>(() => endPoint.FindOneOptional(null as string));
        }

        [Fact]
        public void FindOneOptional_DoesAcceptNullFilter()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint.FindOneOptional(null as ISearchFilter);
            Assert.True(response.HasValue);
            Assert.Equal(response.Value, TestModel.Test1);
        }
        #endregion

        #region Get
        [Fact]
        public void GetAll()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_NONE));
            var response = endPoint.GetAll();
            Assert.Empty(response);
            Assert.Equal<long>(0L, response.Total);
        }

        [Fact]
        public void GetAll_MultipleBatches()
        {
            var endPoint = new EndPoint<TestModel>(MultipleUseApi(out var queue));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST1_STRING} ] }}"));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST2_STRING} ] }}"));
            var response = endPoint.GetAll();
            Assert.Equal<long>(2L, response.Total);
            Assert.Collection(response,
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
        }

        [Fact]
        public void GetAll_MultipleBatches_DoesNotInfiniteLoop()
        {
            var endPoint = new EndPoint<TestModel>(MultipleUseApi(out var queue));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST1_STRING} ] }}"));
            queue.Enqueue(new FakeResponse(@"{ ""total"": 2, ""rows"": [ ] }"));
            Assert.Throws<ApiReturnedInsufficientValuesForRequestException>(() => {
                endPoint.GetAll();
            });
        }

        [Fact]
        public void GetAll_MultipleBatches_ReturnsFailedBatch()
        {
            var endPoint = new EndPoint<TestModel>(MultipleUseApi(out var queue));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST1_STRING} ] }}"));
            queue.Enqueue(new FakeResponse(FIND_ERROR));
            Assert.Throws<ApiErrorException>(() => {
                endPoint.GetAll();
            });
        }

        [Fact]
        public void GetAll_MultipleBatches_DoesNotOverfetch()
        {
            var endPoint = new EndPoint<TestModel>(MultipleUseApi(out var queue));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST1_STRING} ] }}"));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST2_STRING} ] }}"));
            queue.Enqueue(new FakeResponse($@"{{ ""total"": 2, ""rows"": [ {TEST2_STRING} ] }}"));
            var response = endPoint.GetAll();
            Assert.Equal<long>(2L, response.Total);
            Assert.Collection(response,
                a => Assert.Equal(TestModel.Test1, a),
                a => Assert.Equal(TestModel.Test2, a));
            Assert.Single(queue);
        }

        [Fact]
        public void GetAllOptional()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_NONE));
            var response = endPoint.GetAllOptional();
            Assert.False(response.HasValue);
        }

        [Fact]
        public void Get_ById()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(TEST1_STRING));
            var response = endPoint.Get(1);
            Assert.Equal(TestModel.Test1, response);
        }

        [Fact]
        public void Get_ById_WithOperator()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(TEST1_STRING));
            var response = endPoint[1];
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Get_ByName_Operator(bool isCaseSensitive)
        {
            // using FIND_ALL_TWO_ROWS because ByName does a search, not a lookup
            var endPoint = new EndPoint<TestModel>(SingleUseApi(FIND_ALL_TWO_ROWS));
            var response = endPoint["Test1", caseSensitive: isCaseSensitive];
            Assert.Equal(TestModel.Test1, response);
        }

        [Fact]
        public void Get_ByName_DoesNotAcceptNull()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi());
            Assert.Throws<ArgumentNullException>(() => endPoint.Get(null));
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
        [Fact]
        public void Create_Successful()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi($@"
            {{
                ""status"":""success"",
                ""messages"":""TestModel created successfully."",
                ""payload"": {TEST1_STRING}
            }}
            "));
            var response = endPoint.Create(new TestModel {
                Name = "Test1"
            });
            Assert.Equal(TestModel.Test1, response);
        }

        [Fact]
        public void Create_Failure()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi());
            var ex = Assert.Throws<MissingRequiredFieldException<TestModel>>(() => endPoint.Create(new TestModel()));
            Assert.Equal("Missing required field \"Name\" in object of type \"SnipeSharp.Tests.TestModel\"", ex.Message);
        }

        [Fact]
        public void Delete()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(@"
            {
                ""status"": ""success"",
                ""messages"": ""The TestModel was deleted successfully."",
                ""payload"": null
            }
            "));
            var response = endPoint.Delete(1);
            Assert.Equal("success", response.Status);
            Assert.Null(response.Payload);
            Assert.Collection(response.Messages.Keys, a => Assert.Equal("general", a));
            Assert.Collection(response.Messages.Values, a => Assert.Equal("The TestModel was deleted successfully.", a));
            Assert.Equal("success: The TestModel was deleted successfully.", response.ToString());
        }

        [Fact]
        public void Delete_ApiFailure()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(@"
            {
                ""status"": ""error"",
                ""messages"": ""It didn't work."",
                ""payload"": null
            }
            "));
            Assert.Throws<ApiErrorException>(() => endPoint.Delete(1));
        }

        [Fact]
        public void Delete_ApiFailure_MessageDictionary()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(@"
            {
                ""status"": ""error"",
                ""messages"": { ""why"": ""It didn't work."" },
                ""payload"": null
            }
            "));
            var ex = Assert.Throws<ApiErrorException>(() => endPoint.Delete(1));
            Assert.Collection(ex.Messages.Keys, a => Assert.Equal("why", a));
            Assert.Collection(ex.Messages.Values, a => Assert.Equal("It didn't work.", a));
        }

        [Fact]
        public void Update()
        {
            var endPoint = new EndPoint<TestModel>(SingleUseApi(@"
            {
                ""status"": ""success"",
                ""messages"": ""TestModel updated successfully."",
                ""payload"":
                {
                    ""id"": 1,
                    ""name"": ""Test3""
                }
            }
            "));
            var response = endPoint.Update(TestModel.Test1);
            Assert.Equal(new TestModel(1, "Test3", null, null), response);
        }
        #endregion

        [Fact]
        public void ErrorResponseThrowsException()
        {
            Assert.Throws<ApiErrorException>(() => {
               SingleUseApi("{\"status\":\"error\",\"messages\":\"Statuslabel not found\",\"payload\":null}").StatusLabels.Get(0);
            });
        }

        [Fact]
        public void HttpErrorThrowsException()
        {
            Assert.Throws<ApiErrorException>(() => {
                SingleUseApi("{\"status\":\"error\",\"messages\":\"404 endpoint not found\",\"payload\":null}", false, HttpStatusCode.NotFound).StatusLabels.Get(0);
            });
        }
    }
}
