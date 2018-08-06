using System;
using Newtonsoft.Json;

namespace SnipeSharp.Serialization
{
    /// <summary>
    /// Identifies a converter to use when creating objects in an <see cref="SnipeSharp.EndPoint.EndPoint{T}">EndPoint</see>.
    /// </summary>
    public class CreationConverterAttribute: Attribute
    {
        /// <value>The converter to use.</value>
        public JsonConverter Converter { get; private set; }

        /// <summary>
        /// Initializes a new instance of the CreationConverterAttribute class with the specified converter type.
        /// </summary>
        /// <param name="converterType">The converter type to instantiate for use when creating objects.</param>
        public CreationConverterAttribute(Type converterType)
        {
            if(!converterType.IsSubclassOf(typeof(JsonConverter)))
                throw new ArgumentException("Must be a subtype of Newtonsoft.Json.JsonConverter", nameof(converterType));
            Converter = (JsonConverter) converterType.GetConstructor(Type.EmptyTypes).Invoke(null);
        }
    }
}
