using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SnipeSharp.Generator
{
    internal sealed class SortColumnSyntaxReceiver : ISyntaxContextReceiver
    {
        public List<SortColumnEnum> SortColumnEnums { get; } = new List<SortColumnEnum>();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if(context.Node is not EnumDeclarationSyntax syntax)
                return;
            if(context.SemanticModel.GetDeclaredSymbol(syntax) is not INamedTypeSymbol symbol)
                return;
            if(!symbol.TryGetAttribute(Static.SortColumnAttributeFullName, out var _))
                return;
            SortColumnEnums.Add(new SortColumnEnum(symbol));
        }
    }

    internal sealed class SortColumnEnum
    {
        public INamedTypeSymbol Symbol { get; }
        public List<SortColumnValue> Values { get; } = new List<SortColumnValue>();

        public string Name => Symbol.Name;
        public string FullName { get;}
        public string Namespace { get; }

        public SortColumnEnum(INamedTypeSymbol symbol)
        {
            Symbol = symbol;
            FullName = symbol.ToDisplayString();
            Namespace = symbol.ContainingNamespace.ToDisplayString();
            foreach(var member in symbol.GetMembers().OfType<IFieldSymbol>())
                if(member.TryGetAttribute(Static.EnumMemberAttributeFullName, out var attr))
                Values.Add(new SortColumnValue(member, attr));
        }
    }

    internal sealed class SortColumnValue
    {
        public string Name { get; }
        public string Key { get; }

        public SortColumnValue(IFieldSymbol symbol, AttributeData enumMember)
        {
            Name = symbol.Name;
            Key = enumMember.TryGetOption("Value", out var value) && !value.IsNull
                    ? value!.ToString()
                    : symbol.Name.ToLowerInvariant();
        }
    }
}
