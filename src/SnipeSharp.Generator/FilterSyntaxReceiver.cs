using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace SnipeSharp.Generator
{
    internal sealed class FilterSyntaxReceiver : ISyntaxContextReceiver
    {
        public Dictionary<string, FilterDefinition> Definitions { get; } = new Dictionary<string, FilterDefinition>();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if(context.Node is not ClassDeclarationSyntax decl)
                return;
            if(context.SemanticModel.GetDeclaredSymbol(decl) is not INamedTypeSymbol symbol)
                return;
            if(!symbol.TryGetAttribute(Static.GenerateFilterAttributeFullName, out var attr))
                return;
            if(!symbol.Interfaces.Any(a => a.Name == "IFilter"))
                return;
            Definitions[symbol.Name] = new FilterDefinition(symbol, attr);
        }
    }

    internal sealed class FilterDefinition
    {
        public INamedTypeSymbol Symbol { get; }
        public bool HasSearchString { get; }
        public string[] FilterTypes { get; }
        public string Modifier { get; }

        public List<FilterProperty> Properties = new List<FilterProperty>();

        public FilterDefinition(INamedTypeSymbol symbol, AttributeData attr)
        {
            Symbol = symbol;
            Modifier = symbol.DeclaredAccessibility.AsString();
            FilterTypes = symbol.Interfaces.Where(a => a.Name == "IFilter").Select(a => a.ToDisplayString()).ToArray();

            if(attr.TryGetOption(nameof(HasSearchString), out var hasSearchString) ? hasSearchString.Value is bool b && b : true)
            {
                HasSearchString = true;
                Properties.Add(FilterProperty.SearchString);
            }

            if(attr.TryGetOption(0, out var columnType) && columnType.Value is INamedTypeSymbol s)
                Properties.Add(new FilterProperty("sort", s.Nullable(), "SortOn", "SortOn?.Serialize()"));

            foreach(var member in symbol.GetMembers())
            {
                if(member is not IPropertySymbol memberProperty)
                    continue;
                if(!memberProperty.TryGetAttribute(Static.SerializeAsStringAttributeFullName, out var serializeAsAttr))
                    continue;
                if(!serializeAsAttr.TryGetOption(0, out var keyConstant) || keyConstant.IsNull)
                    continue;
                var property = new FilterProperty
                {
                    Name = member.Name,
                    Key = keyConstant.Value!.ToString(),
                    Type = memberProperty.Type.ToDisplayString(),
                };
                if(serializeAsAttr.TryGetOption("With", out var withConstant) && withConstant.Value is string convertWith)
                    property.ConvertWith = convertWith;
                else
                    property.ConvertWith = $"{member.Name}?.ToString()";
            }
        }
    }

    internal sealed class FilterProperty
    {
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ConvertWith { get; set; } = string.Empty;

        public FilterProperty(){}
        public FilterProperty(string key, string type, string name, string convertwith): this(key, type, name)
        {
            ConvertWith = convertwith;
        }

        public FilterProperty(string key, string type, string name)
        {
            Key = key;
            Type = type;
            Name = name;
            ConvertWith = $"{name}?.ToString()";
        }

        public static readonly FilterProperty SearchString = new FilterProperty("search", "string?", "SearchString", "SearchString");
    }
}
