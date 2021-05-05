using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SnipeSharp.Generator
{
    internal sealed class PartialTypeSyntaxReceiver : ISyntaxContextReceiver
    {
        public Dictionary<string, PartialClass> PartialClasses { get; } = new Dictionary<string, PartialClass>();
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if(context.Node is not ClassDeclarationSyntax syntax)
                return;
            if(context.SemanticModel.GetDeclaredSymbol(syntax) is not INamedTypeSymbol symbol)
                return;
            if(!symbol.TryGetAttribute(Static.GeneratePartialAttributeFullName, out var attr))
                return;
            PartialClasses[symbol.Name] = new PartialClass(symbol, attr);
        }
    }

    internal sealed class PartialClass
    {
        public INamedTypeSymbol Symbol { get; }

        public string Name => Symbol.Name;
        public string Namespace => Symbol.ContainingNamespace.ToDisplayString();
        public string FullName => Symbol.ToDisplayString();

        public string Modifiers { get; }

        public List<PartialProperty> Properties { get; } = new List<PartialProperty>();

        public List<PartialActionStruct> ActionStructs { get; } = new List<PartialActionStruct>();

        public PartialClass(INamedTypeSymbol symbol, AttributeData attr)
        {
            Symbol = symbol;

            foreach(var member in symbol.GetMembers().Where(a => a is IPropertySymbol).Select(a => (IPropertySymbol)a))
                if(member.TryGetAttribute(Static.DeserializeAsAttributeFullName, out var deserialize))
                    Properties.Add(new PartialProperty(member, deserialize));

            foreach(var member in symbol.GetMembers().Where(a => a is IFieldSymbol).Select(a => (IFieldSymbol)a))
                if(member.TryGetAttribute(Static.DeserializeAsAttributeFullName, out var deserialize))
                    Properties.Add(new PartialProperty(member, deserialize));

            foreach(var member in symbol.GetTypeMembers().Where(a => a.TryGetAttribute(Static.GeneratePartialActionsAttributeFullName, out var _)))
                ActionStructs.Add(new PartialActionStruct(member));

            Modifiers = symbol.DeclaredAccessibility.AsString();
            if(symbol.IsSealed)
                Modifiers += " sealed";
        }
    }

    internal sealed class PartialProperty
    {
        public string Key { get; }
        public string Type { get; }
        public string Name { get; }

        internal PartialProperty(IPropertySymbol symbol, AttributeData attr)
        {
            if(!attr.TryGetOption(0, out var key) || key.IsNull)
                throw new ArgumentException();
            Key = key.Value!.ToString();
            Name = symbol.Name;
            var typeName = attr.TryGetOption("Type", out var type) && type.Value is ITypeSymbol typeSymbol
                ? typeSymbol.ToDisplayString()
                : symbol.Type.ToDisplayString();
            if(attr.TryGetOption("IsNonNullable", out var inn) && inn.Value is bool b ? !b : true)
                if(!typeName.EndsWith("?"))
                    typeName += "?";
            Type = typeName;
        }

        internal PartialProperty(IFieldSymbol symbol, AttributeData attr)
        {
            if(!attr.TryGetOption(0, out var key) || key.IsNull)
                throw new ArgumentException();
            Key = key.Value!.ToString();
            Name = symbol.Name;
            var typeName = attr.TryGetOption("Type", out var type) && type.Value is ITypeSymbol typeSymbol
                ? typeSymbol.ToDisplayString()
                : symbol.Type.ToDisplayString();
            if(attr.TryGetOption("IsNonNullable", out var inn) && inn.Value is bool b ? !b : true)
                if(!typeName.EndsWith("?"))
                    typeName += "?";
            Type = typeName;
        }
    }

    internal sealed class PartialActionStruct
    {
        public INamedTypeSymbol Symbol { get; }
        public List<PartialActionStructProperty> Properties { get; } = new List<PartialActionStructProperty>();
        public string Modifier { get; }
        public bool NeedsConstructor { get; }
        public bool NeedsToString { get; }

        public string Name => Symbol.Name;

        internal PartialActionStruct(INamedTypeSymbol symbol)
        {
            Symbol = symbol;
            foreach(var property in symbol.GetMembers().OfType<IPropertySymbol>())
                Properties.Add(new PartialActionStructProperty(property));
            NeedsConstructor = symbol.Constructors.Length == 1 && symbol.Constructors[0].Parameters.Length == 0;
            NeedsToString = !symbol.GetMembers("ToString").Any(m => m is IMethodSymbol);
            Modifier = symbol.DeclaredAccessibility.AsString();
        }
    }

    internal sealed class PartialActionStructProperty
    {
        public string Name { get; }
        public string Key { get; }

        internal PartialActionStructProperty(IPropertySymbol property)
        {
            Name = property.Name;
            Key = "Static.Actions." + property.Name.ToUpperInvariant();
        }
    }
}
