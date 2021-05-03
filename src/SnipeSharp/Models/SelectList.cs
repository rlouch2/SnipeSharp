using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    public struct Pagination
    {
        int PerPage { get; }
        bool HasMore { get; }

        internal Pagination(Serialization.PartialPagination partial)
        {
            PerPage = partial.PerPage ?? throw new ArgumentNullException(nameof(PerPage));
            HasMore = partial.HasMore ?? throw new ArgumentNullException(nameof(HasMore));
        }
    }

    [JsonConverter(typeof(Serialization.SelectListConverterFactor))]
    public sealed class SelectList<T>: IEnumerable<SelectItem<T>>, IReadOnlyList<SelectItem<T>>
        where T: class
    {
        public int Page { get; }
        public int PageCount { get; }
        public int TotalCount { get; }
        public SelectItem<T>[] Results { get; }
        public readonly Pagination Pagination;

        internal SelectList(Serialization.PartialSelectList<T> partial)
        {
            Page = partial.Page ?? throw new ArgumentNullException(nameof(Page));
            PageCount = partial.PageCount ?? throw new ArgumentNullException(nameof(Page));
            TotalCount = partial.TotalCount ?? throw new ArgumentNullException(nameof(Page));
            Results = partial.Results ?? throw new ArgumentNullException(nameof(Page));
            Pagination = new Pagination(partial.Pagination ?? throw new ArgumentNullException(nameof(Pagination)));
        }

        int IReadOnlyCollection<SelectItem<T>>.Count => Results.Length;
        public SelectItem<T> this[int index] => Results[index];
        public IEnumerator<SelectItem<T>> GetEnumerator() => ((IEnumerable<SelectItem<T>>)Results).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Results.GetEnumerator();
    }

    public sealed class SelectItem<T>: IApiObject<T>
    {
        public int Id { get; }
        public string Text { get; }
        public string? Image { get; }

        internal SelectItem(Serialization.PartialSelectItem partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Text = partial.Text ?? throw new ArgumentNullException(nameof(Text));
            Image = partial.Image;
        }
    }

    namespace Serialization
    {
        internal sealed class SelectListConverterFactor : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
                => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(SelectList<>);

            public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
                => (JsonConverter?)Activator.CreateInstance(
                        typeof(SelectListConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()),
                        BindingFlags.Public | BindingFlags.Instance,
                        binder: null, args: Array.Empty<object>(), culture: null);
        }

        internal sealed class PartialPagination
        {
            [JsonPropertyName("more")]
            public bool? HasMore { get; set; }

            [JsonPropertyName("per_page")]
            public int? PerPage { get; set; }
        }

        internal sealed class PartialSelectList<T>
        {
            [JsonPropertyName("page")]
            public int? Page { get; set; }

            [JsonPropertyName("page_count")]
            public int? PageCount { get; set; }

            [JsonPropertyName("total_count")]
            public int? TotalCount { get; set; }

            [JsonPropertyName("pagination")]
            public PartialPagination? Pagination { get; set; }

            [JsonPropertyName("results")]
            public SelectItem<T>[]? Results { get; set; }
        }

        internal sealed class SelectListConverter<T> : JsonConverter<SelectList<T>>
            where T: class
        {
            public override SelectList<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialSelectList<T>>(ref reader, options);
                if(null == partial)
                    return null;
                return new SelectList<T>(partial);
            }

            public override void Write(Utf8JsonWriter writer, SelectList<T> value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class SelectItemConverterFactor : JsonConverterFactory
        {
            public override bool CanConvert(Type typeToConvert)
                => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(SelectItem<>);

            public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
                => (JsonConverter?)Activator.CreateInstance(
                        typeof(SelectItemConverter<>).MakeGenericType(typeToConvert.GetGenericArguments()),
                        BindingFlags.Public | BindingFlags.Instance,
                        binder: null, args: Array.Empty<object>(), culture: null);
        }

        internal sealed class PartialSelectItem
        {
            [JsonPropertyName("id")]
            public int? Id;

            [JsonPropertyName("text")]
            public string? Text;

            [JsonPropertyName("image")]
            public string? Image;
        }

        internal sealed class SelectItemConverter<T> : JsonConverter<SelectItem<T>>
            where T: class
        {
            public override SelectItem<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialSelectItem>(ref reader, options);
                if(null == partial)
                    return null;
                return new SelectItem<T>(partial);
            }

            public override void Write(Utf8JsonWriter writer, SelectItem<T> value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }
    }
}
