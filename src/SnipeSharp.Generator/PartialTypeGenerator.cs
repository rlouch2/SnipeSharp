using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SnipeSharp.Generator
{
    [Generator]
    public sealed class PartialTypeGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization(ctx => ctx.AddSource("PartialTypeAttributes", SourceText.From(ATTRIBUTES, Encoding.UTF8)));
            context.RegisterForSyntaxNotifications(() => new PartialTypeSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if(context.SyntaxContextReceiver is not PartialTypeSyntaxReceiver receiver)
                return;
            foreach(var definition in receiver.PartialClasses.Values)
            {
                var builder = new StringBuilder($@"
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using SnipeSharp;

namespace {definition.Namespace}
{{
    internal sealed class Partial{definition.Name}
    {{");
                foreach(var property in definition.Properties)
                    builder.Append($@"
        [JsonPropertyName(""{property.Key}"")]
        public {property.Type} {property.Name} {{ get; set; }}");

                foreach(var type in definition.ActionStructs)
                {
                    builder.Append($@"
        public struct {type.Name}
        {{");
                    foreach(var property in type.Properties)
                        builder.Append($@"
            [JsonPropertyName(""{property.Key}"")]
            public bool {property.Name} {{ get; set; }}");
                    builder.Append(@"
        }");
                }

                builder.Append(@"
    }");

                var partialStructs = definition.ActionStructs.Where(a => a.NeedsConstructor || a.NeedsToString).ToList();
                if(partialStructs.Count > 0)
                {
                    builder.Append($@"
    {definition.Modifiers} partial class {definition.Name}
    {{");
                    foreach(var type in partialStructs)
                    {
                        builder.Append($@"
        {type.Modifier} partial struct {type.Name}
        {{");
                        if(type.NeedsConstructor)
                        {
                            builder.Append($@"
            internal {type.Name}(Partial{definition.Name}.{type.Name} partial)
            {{");
                            foreach(var property in type.Properties)
                                builder.Append($@"
                {property.Name} = partial.{property.Name};");
                            builder.Append(@"
            }");
                        }

                        if(type.NeedsToString)
                        {
                            builder.Append(@"
            public override string ToString()
            {
                var joiner = new StringJoiner(""{"", "","", ""}"");");
                            foreach(var property in type.Properties)
                                builder.Append($@"
                if({property.Name})
                    joiner.Append(nameof({property.Name}));");
                            builder.Append(@"
                return joiner.ToString();
            }");
                        }

                        builder.Append(@"
        }");
                    }

                    builder.Append(@"
    }");
                }

                builder.Append(@"
}
");
                context.AddSource($"Partial{definition.Name}_generated", SourceText.From(builder.ToString(), Encoding.UTF8));
            }
        }

        private const string ATTRIBUTES = $@"
using System;

namespace {Static.Namespace}
{{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class {Static.GeneratePartialAttribute}: Attribute
    {{
    }}

    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class {Static.GeneratePartialActionsAttribute}: Attribute
    {{
    }}
}}
";
    }
}
