using System.Collections.Generic;

namespace SnipeSharp.EndPoint.Models
{
    /// <summary>
    /// Indicates that this object supports custom fields.
    /// </summary>
    /// <typeparam name="T">The type of the values of the custom fields.</typeparam>
    internal interface ICustomFields<T>
    {
        /// <summary>
        /// The custom fields of this object.
        /// </summary>
        Dictionary<string, T> CustomFields { get; set; }
    }
}