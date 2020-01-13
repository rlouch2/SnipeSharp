using System;

namespace SnipeSharp.Serialization
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class PatchAttribute : System.Attribute
    {
        internal readonly string IndicatorFieldName;
        internal PatchAttribute(string indicatorFieldName)
        {
            IndicatorFieldName = indicatorFieldName;
        }
    }
}
