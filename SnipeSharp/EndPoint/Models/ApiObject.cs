using System;
using System.Collections.Generic;
using System.Reflection;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// Represents the the base of all objects we get back the API.  This is the building block for all more 
    /// specific return objects. 
    /// </summary>
    public class ApiObject
    {
        // just so there's a base between requestresponse and commonendpointmodel
    }

    public abstract class CommonEndPointModel: ApiObject
    {
        public abstract long Id { get; set; }
        public abstract string Name { get; set; }
        public abstract DateTime CreatedAt { get; set; }
        public abstract DateTime UpdatedAt { get; set; }

        // TODO - We're doing this so when it's passed in the header for create action we get the ID
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}