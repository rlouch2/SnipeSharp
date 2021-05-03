using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.DataTableSerializerFactory))]
    public sealed class DataTable<T>: IEnumerable<T>, IReadOnlyList<T>
        where T: class
    {
        public int Total { get; }

        internal List<T> Value { get; }
        public IReadOnlyList<T> Rows => Value;


        internal DataTable(int total, T[] rows)
        {
            Total = total;
            Value = new List<T>(rows);
        }

        public int Count => Rows.Count;
        public T this[int index] => Rows[index];
        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)Value).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();
    }

    namespace Serialization
    {
        internal sealed class DataTableSerializerFactory: JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
                => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(DataTable<>);

            public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
                => (JsonConverter?)Activator.CreateInstance(
                    typeof(DataTableSerializer<>).MakeGenericType(typeToConvert.GetGenericArguments()),
                    BindingFlags.Public | BindingFlags.Instance,
                    binder: null, args: Array.Empty<object>(), culture: null);
        }

        internal sealed class PartialDataTable<T>
        {
            [JsonPropertyName("total")]
            public int? Total { get; set; }

            [JsonPropertyName("rows")]
            public T[]? Rows { get; set; }
        }

        internal sealed class DataTableSerializer<T>: JsonConverter<DataTable<T>>
            where T: class
        {
            public override DataTable<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialDataTable<T>>(ref reader, options);
                if(null == partial)
                    return null;
                return new DataTable<T>(
                    partial.Total ?? throw new MissingRequiredPropertyException(nameof(PartialDataTable<T>.Total), nameof(DataTable<T>)),
                    partial.Rows ?? throw new MissingRequiredPropertyException(nameof(PartialDataTable<T>.Total), nameof(DataTable<T>)));
            }

            public override void Write(Utf8JsonWriter writer, DataTable<T> value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
