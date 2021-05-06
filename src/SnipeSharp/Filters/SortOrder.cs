using System.Runtime.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp
{
    [SortColumn]
    public enum SortOrder
    {
        [EnumMember(Value = "desc")]
        Descending = 0,

        [EnumMember(Value = "asc")]
        Ascending = 1
    }
}
