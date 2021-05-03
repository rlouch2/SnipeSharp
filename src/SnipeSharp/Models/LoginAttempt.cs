using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(Serialization.LoginAttemptConverter))]
    public sealed class LoginAttempt: IApiObject<LoginAttempt>
    {
        public int Id { get; }
        public string Username { get; }
        public string UserAgent { get; }
        public IPAddress? RemoteIPAddress { get; }
        public bool? IsSuccessful { get; }
        public FormattedDateTime CreatedAt { get; }

        internal LoginAttempt(Serialization.PartialLoginAttempt partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Username = partial.Username ?? throw new ArgumentNullException(nameof(Username));
            UserAgent = partial.UserAgent ?? throw new ArgumentNullException(nameof(UserAgent));
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));

            IsSuccessful = partial.Successful switch {
                null => throw new ArgumentNullException(nameof(IsSuccessful)),
                "1" => true,
                "0" => false,
                _ => null
            };

            if(IPAddress.TryParse(partial.RemoteIPAddress ?? throw new ArgumentNullException(nameof(RemoteIPAddress)), out var ip))
                RemoteIPAddress = ip;
        }
    }

    public enum LoginAttemptSortOn
    {
        CreatedAt = 0,
        Id,
        IsSuccessful, Successful = IsSuccessful,
        RemoteIPAddress, RemoteIP = RemoteIPAddress,
        UserAgent,
        Username,
    }

    internal static class LoginAttemptSortOnExtensions
    {
        internal static string? Serialize(this LoginAttemptSortOn? column)
            => column switch
            {
                LoginAttemptSortOn.CreatedAt => "created_at",
                LoginAttemptSortOn.Id => "id",
                LoginAttemptSortOn.IsSuccessful => "successful",
                LoginAttemptSortOn.RemoteIPAddress => "remote_up",
                LoginAttemptSortOn.UserAgent => "user_agent",
                LoginAttemptSortOn.Username => "username",
                _ => null
            };
    }

    public sealed class LoginAttemptFilter : IFilter<LoginAttempt>
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public SortOrder? SortOrder { get; set; }
        public LoginAttemptSortOn? SortOn { get; set; }

        IFilter<LoginAttempt> IFilter<LoginAttempt>.Clone()
            => new LoginAttemptFilter
            {
                Limit = Limit,
                Offset = Offset,
                SortOrder = SortOrder,
                SortOn = SortOn,
            };

        IReadOnlyDictionary<string, string?> IFilter<LoginAttempt>.GetParameters()
        {
            var dict = new Dictionary<string, string?>();
            if(null != Limit)
                dict["limit"] = Limit.ToString();
            if(null != Offset)
                dict["offset"] = Offset.ToString();
            if(null != SortOrder)
                dict["order"] = SortOrder.Serialize();
            if(null != SortOn)
                dict["sort"] = SortOn.Serialize();
            return dict;
        }
    }

    namespace Serialization
    {
        internal sealed class LoginAttemptConverter : JsonConverter<LoginAttempt>
        {
            public override LoginAttempt? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var partial = JsonSerializer.Deserialize<PartialLoginAttempt>(ref reader, options);
                if(null == partial)
                    return null;
                return new LoginAttempt(partial);
            }

            public override void Write(Utf8JsonWriter writer, LoginAttempt value, JsonSerializerOptions options)
                => throw new NotImplementedException();
        }

        internal sealed class PartialLoginAttempt
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("username")]
            public string? Username { get; set; }

            [JsonPropertyName("user_agent")]
            public string? UserAgent { get; set; }

            [JsonPropertyName("remote_ip")]
            public string? RemoteIPAddress { get; set; }

            [JsonPropertyName("successful")]
            public string? Successful { get; set; }

            [JsonPropertyName("created_at")]
            public FormattedDateTime? CreatedAt { get; set; }
        }
    }
}
