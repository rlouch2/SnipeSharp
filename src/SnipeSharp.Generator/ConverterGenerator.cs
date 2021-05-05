using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SnipeSharp.Generator
{
    [Generator]
    public sealed class ConverterGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization(ctx => ctx.AddSource("ConverterAttributes", SourceText.From(ATTRIBUTES, Encoding.UTF8)));
            context.RegisterForSyntaxNotifications(() => new ConverterSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if(context.SyntaxContextReceiver is not ConverterSyntaxReceiver receiver)
                return;
            foreach(var definition in receiver.Classes.Values)
            {
                context.AddSource($"{definition.Name}Converter_generated", SourceText.From($@"
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using SnipeSharp;

namespace {definition.Namespace}
{{
    internal sealed class {definition.Name}Converter: JsonConverter<{definition.Name}>
    {{
        public override {definition.NullableName} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {{
            var partial = JsonSerializer.Deserialize<{definition.PartialName}>(ref reader, options);
            if(null == partial)
                return null;
            return new {definition.FullName}(partial);
        }}

        public override void Write(Utf8JsonWriter writer, {definition.FullName} value, JsonSerializerOptions options)
            => throw new NotImplementedException();
    }}
}}", Encoding.UTF8));
            }
        }

        private const string ATTRIBUTES = $@"
using System;

namespace {Static.Namespace}
{{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class {Static.GenerateConverterAttribute}: Attribute
    {{
        public Type? PartialType {{ get; }}

        public {Static.GenerateConverterAttribute}()
        {{
            // infer partial type from attached type.
        }}

        public {Static.GenerateConverterAttribute}(Type partialType)
        {{
            PartialType = partialType;
        }}
    }}
}}
";
    }
}
