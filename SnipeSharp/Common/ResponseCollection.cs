using SnipeSharp.Endpoints.Models;
using SnipeSharp.JsonConverters;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace SnipeSharp.Common
{
    public class ResponseCollection<T> : IResponseCollection<T>
    {
        [DeserializeAs(Name = "total")]
        public long Total { get; set; }

        [DeserializeAs(Name = "rows")]
        //[JsonConverter(typeof(DetectJsonObjectType))]
        public List<T> Rows { get; set; }
    }
}
