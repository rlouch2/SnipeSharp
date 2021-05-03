using System;
using System.Collections.Generic;
using System.Text;

namespace SnipeSharp
{
    internal static class UriExtensions
    {
        internal static IDictionary<string, string?> GetQueryParameters(this Uri uri)
        {
            var dictionary = new Dictionary<string, string?>();
            if(string.IsNullOrEmpty(uri.Query))
                return dictionary;
            foreach(var pair in uri.Query.Substring(1).Split('&'))
            {
                var components = pair.Split('=');
                var key = Uri.UnescapeDataString(components[0]);
                dictionary[key] = components.Length > 1 ? Uri.UnescapeDataString(components[1]) : null;
            }
            return dictionary;
        }

        internal static string AsQueryParameters(this IReadOnlyDictionary<string, string?> parameters)
        {
            var stringBuilder = new StringBuilder();
            var joiner = "";
            foreach(var pair in parameters)
            {
                stringBuilder.Append(Uri.EscapeDataString(pair.Key));
                if(null != pair.Value)
                    stringBuilder.Append('=').Append(Uri.EscapeDataString(pair.Value));
                stringBuilder.Append(joiner);
                joiner = "&";
            }
            return stringBuilder.ToString();
        }

        internal static UriBuilder SetQueryParameters(this UriBuilder builder, IReadOnlyDictionary<string, string?> parameters)
        {
            builder.Query = parameters.AsQueryParameters();
            return builder;
        }
    }
}
