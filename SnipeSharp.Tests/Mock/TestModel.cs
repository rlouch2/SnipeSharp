using System;
using SnipeSharp.EndPoint;
using SnipeSharp.Models;

namespace SnipeSharp.Tests.Mock
{
    [PathSegment("test")]
    internal sealed class TestModel : CommonEndPointModel
    {
        public override int Id { get; protected set; }
        public override string Name { get; set; }
        public override DateTime? CreatedAt { get; protected set; }
        public override DateTime? UpdatedAt { get; protected set; }
    }

    internal sealed class FaultyTestModel : CommonEndPointModel
    {
        public override int Id { get; protected set; }
        public override string Name { get; set; }
        public override DateTime? CreatedAt { get; protected set; }
        public override DateTime? UpdatedAt { get; protected set; }
    }
}
