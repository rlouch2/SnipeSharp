using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace SnipeSharp.Generator
{
    [Generator]
    public sealed class SortColumnExtensionGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization(ctx => ctx.AddSource("SerializationAttributes", SERIALIZATION_ATTRIBUTES));
            context.RegisterForSyntaxNotifications(() => new SortColumnSyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if(context.SyntaxContextReceiver is not SortColumnSyntaxReceiver receiver)
                return;

            foreach(var sortEnum in receiver.SortColumnEnums)
            {
                var builder = new StringBuilder($@"
namespace {sortEnum.Namespace}
{{
    internal static class {sortEnum.Name}Extensions
    {{
        internal static string? Serialize(this {sortEnum.FullName} value)
            => value switch
            {{");

                foreach(var member in sortEnum.Values)
                    builder.Append($@"
                {sortEnum.FullName}.{member.Name} => ""{member.Key}"",");

                builder.Append(@"
                _ => null
            };
    }
}
");
                context.AddSource($"{sortEnum.Name}_generated", SourceText.From(builder.ToString(), Encoding.UTF8));
            }
        }

        private const string SERIALIZATION_ATTRIBUTES = $@"
using System;

namespace {Static.Namespace}
{{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    internal sealed class {Static.DeserializeAsAttribute}: Attribute
    {{
        public string Key {{ get; }}

        public Type? Type {{ get; set; }}

        public bool IsNonNullable {{ get; set; }}

        public {Static.DeserializeAsAttribute}(string key)
        {{
            Key = key;
        }}
    }}

    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    internal sealed class {Static.SortColumnAttribute}: Attribute
    {{
    }}
}}
";
    }
}
