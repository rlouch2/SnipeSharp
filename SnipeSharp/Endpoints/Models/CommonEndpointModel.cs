using SnipeSharp.Attributes;
using SnipeSharp.Common;
using SnipeSharp.Exceptions;
using SnipeSharp.JsonConverters;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using Newtonsoft.Json;

/// <summary>
/// Represents the the base of all objects we get back the API.  This is the building block for all more 
/// specific return objects. 
/// </summary>
namespace SnipeSharp.Endpoints.Models
{
    public class CommonEndpointModel : ICommonEndpointModel
    {
        [DeserializeAs(Name = "id")]
        public long Id { get; set; }

        [DeserializeAs(Name = "name")]
        [SerializeAs(Name = "name")]
        [RequiredField]
        public string Name { get; set; }

        [DeserializeAs(Name = "created_at")]
        [JsonConverter(typeof(ResponseDateTimeConverter))]
        public ResponseDate CreatedAt { get; set; }

        [DeserializeAs(Name = "updated_at")]
        [JsonConverter(typeof(ResponseDateTimeConverter))]
        public ResponseDate UpdatedAt { get; set; }

        // TODO - We're doing this so when it's passed in the header for create action we get the ID
        public override string ToString()
        {
            return Id.ToString();
        }

        /// <summary>
        /// Loop through all properties of this model, looking for any tagged with our custom attributes that we need
        /// to send as request headers
        /// </summary>
        /// <returns>Dictionary of header values</returns>
        // TODO: Get RestSharp to handle this for us.
        public virtual Dictionary<string, string> QueryParameters {
            get {
                var values = new Dictionary<string, string>();
                foreach(var property in this.GetType().GetProperties())
                {
                    var serializeAttribute = property.GetCustomAttribute<SerializeAsAttribute>();
                    if(serializeAttribute == null)
                        continue;
                    var value = property.GetValue(this)?.ToString();
                    if(null != property.GetCustomAttribute<RequiredField>() && value == null) // required but not present
                        throw new RequiredValueIsNullException($"{property.Name} cannot be null");
                    if(value != null)
                        values[serializeAttribute.Name] = value;
                }
                return values;
            }
        }
    }
}
