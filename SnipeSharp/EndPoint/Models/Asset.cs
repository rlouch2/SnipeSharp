using System;

namespace SnipeSharp.EndPoint.Models
{
    public class Asset : CommonEndPointModel
    {
        public override long Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override DateTime UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //TODO
    }

    public class AssetCheckOutRequest: ApiObject
    {

    }

    public class AssetCheckInRequest: ApiObject
    {
        public string Note { get; set; }
        public Location Location { get; set; }
    }
}