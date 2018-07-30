using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    public class User : CommonEndPointModel
    {
        public override long Id { get; set; }
        public override string Name { get; set; }
        public override DateTime? CreatedAt { get; set; }
        public override DateTime? UpdatedAt { get; set; }
        //TODO
    }
}