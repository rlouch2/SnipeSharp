using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SnipeSharp.Generator
{
    internal sealed class ConverterSyntaxReceiver : ISyntaxContextReceiver
    {
        public Dictionary<string, ConverterClass> Classes { get; } = new Dictionary<string, ConverterClass>();
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if(context.Node is not ClassDeclarationSyntax syntax)
                return;
            if(context.SemanticModel.GetDeclaredSymbol(syntax) is not INamedTypeSymbol symbol)
                return;
            if(!symbol.TryGetAttribute(Static.GenerateConverterAttributeFullName, out var attr))
                return;
            Classes[symbol.Name] = new ConverterClass(symbol, attr);
        }
    }

    internal sealed class ConverterClass
    {
        public INamedTypeSymbol Symbol { get; }
        public string PartialName { get;}
        public string NullableName { get; }

        public string Name => Symbol.Name;
        public string Namespace => Symbol.ContainingNamespace.ToDisplayString();
        public string FullName => Symbol.ToDisplayString();


        public ConverterClass(INamedTypeSymbol symbol, AttributeData attr)
        {
            Symbol = symbol;
            NullableName = symbol.Nullable();
            if(attr.TryGetOption(0, out var partial) && partial.Value is ITypeSymbol type)
                PartialName = type.ToDisplayString();
            else
                PartialName = $"Partial{symbol.Name}";
        }
    }
}
