using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnipeSharp.EndPoint.Models
{
    public abstract class CommonEndPointModel: ApiObject
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract DateTime? CreatedAt { get; set; }
        public abstract DateTime? UpdatedAt { get; set; }

        // TODO - We're doing this so when it's passed in the header for create action we get the ID
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}