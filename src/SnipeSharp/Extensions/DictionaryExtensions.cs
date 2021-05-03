using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SnipeSharp
{
    internal static class DictionaryExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Dictionary<K,V> AddIfNotNull<K,V>(this Dictionary<K,V> dictionary, K key, V? value)
            where K: notnull
        {
            if(null != value)
                dictionary[key] = value;
            return dictionary;
        }
    }
}
