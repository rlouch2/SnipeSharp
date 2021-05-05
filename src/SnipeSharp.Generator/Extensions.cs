using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace SnipeSharp.Generator
{
    internal static class Extensions
    {
        internal static bool TryGetAttribute(this ISymbol symbol, ISymbol attribute, out AttributeData data)
        {
            var a = symbol.GetAttributes().SingleOrDefault(a => a?.AttributeClass?.ToDisplayString() == attribute.ToDisplayString());
            if(null == a)
            {
                data = default!;
                return false;
            }
            data = a;
            return true;
        }

        internal static bool TryGetAttribute(this ISymbol symbol, string attribute, out AttributeData data)
        {
            var a = symbol.GetAttributes().SingleOrDefault(a => a?.AttributeClass?.ToDisplayString() == attribute);
            if(null == a)
            {
                data = default!;
                return false;
            }
            data = a;
            return true;
        }


        internal static bool TryGetOption(this AttributeData data, string name, out TypedConstant value)
        {
            var arg = data.NamedArguments.Where(a => a.Key == name).ToArray();
            if(0 == arg.Length)
            {
                value = default!;
                return false;
            }
            value = arg[0].Value;
            return true;
        }

        internal static bool TryGetOption(this AttributeData data, int position, out TypedConstant value)
        {
            if(position >= data.ConstructorArguments.Length)
            {
                value = default!;
                return false;
            }
            value = data.ConstructorArguments[position];
            return true;
        }

        internal static string Nullable(this ITypeSymbol type, AttributeData data)
        {
            var name = type.ToDisplayString();
            if(name.EndsWith("?"))
                return name;
            if(!data.TryGetOption("IsNonNullable", out var opt))
                return name + "?";
            if(opt.Value is bool b && !b)
                return name + "?";
            return name;
        }

        internal static string Nullable(this ITypeSymbol type)
        {
            return type.ToDisplayString() + "?";
        }

        internal static string AsString(this Accessibility accessibility)
            => accessibility switch
            {
                Accessibility.NotApplicable => "",
                Accessibility.Private => "private",
                Accessibility.Protected => "protected",
                Accessibility.Internal => "internal",
                Accessibility.ProtectedOrInternal => "protected internal",
                Accessibility.Public => "public",
                _ => throw new ArgumentException($"Unsupported accessibility type {accessibility}")
            };

        internal static string Quote(this string constant)
            => $"\"{constant}\"";
    }
}
