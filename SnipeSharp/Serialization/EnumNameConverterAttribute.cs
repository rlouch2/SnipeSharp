using System;
namespace SnipeSharp.Serialization
{
    /// <summary>
    /// Goes on enums with <see cref="System.Runtime.Serialization.EnumMemberAttribute"/> on its members,
    /// so <see cref="RestClientManager.ExecuteRequest{R}(RestSharp.Method, string, Models.ApiObject)"/>
    /// actually uses the values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    internal sealed class EnumNameConverterAttribute : Attribute
    {
    }
}
