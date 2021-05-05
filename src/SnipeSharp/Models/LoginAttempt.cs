using System;
using System.Net;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using SnipeSharp.Serialization;

namespace SnipeSharp.Models
{
    [JsonConverter(typeof(LoginAttemptConverter))]
    [GeneratePartial, GenerateConverter]
    public sealed class LoginAttempt: IApiObject<LoginAttempt>
    {
        [DeserializeAs(Static.ID)]
        public int Id { get; }

        [DeserializeAs(Static.USERNAME)]
        public string Username { get; }

        [DeserializeAs(Static.LoginAttempt.USER_AGENT)]
        public string UserAgent { get; }

        [DeserializeAs(Static.LoginAttempt.REMOTE_IP, Type = typeof(string))]
        public IPAddress? RemoteIPAddress { get; }

        [DeserializeAs(Static.LoginAttempt.SUCCESSFUL, Type = typeof(string))]
        public bool? IsSuccessful { get; }

        [DeserializeAs(Static.CREATED_AT)]
        public FormattedDateTime CreatedAt { get; }

        internal LoginAttempt(PartialLoginAttempt partial)
        {
            Id = partial.Id ?? throw new ArgumentNullException(nameof(Id));
            Username = partial.Username ?? throw new ArgumentNullException(nameof(Username));
            UserAgent = partial.UserAgent ?? throw new ArgumentNullException(nameof(UserAgent));
            CreatedAt = partial.CreatedAt ?? throw new ArgumentNullException(nameof(CreatedAt));

            IsSuccessful = partial.IsSuccessful switch {
                null => throw new ArgumentNullException(nameof(IsSuccessful)),
                "1" => true,
                "0" => false,
                _ => null
            };

            if(IPAddress.TryParse(partial.RemoteIPAddress ?? throw new ArgumentNullException(nameof(RemoteIPAddress)), out var ip))
                RemoteIPAddress = ip;
        }
    }

    [SortColumn]
    public enum LoginAttemptSortOn
    {
        [EnumMember(Value = Static.CREATED_AT)]
        CreatedAt = 0,

        [EnumMember(Value = Static.ID)]
        Id,

        [EnumMember(Value = Static.LoginAttempt.SUCCESSFUL)]
        IsSuccessful, Successful = IsSuccessful,

        [EnumMember(Value = Static.LoginAttempt.REMOTE_IP)]
        RemoteIPAddress, RemoteIP = RemoteIPAddress,

        [EnumMember(Value = Static.LoginAttempt.USER_AGENT)]
        UserAgent,

        [EnumMember(Value = Static.USERNAME)]
        Username,
    }

    [GenerateFilter(typeof(LoginAttemptSortOn), HasSearchString = false)]
    public sealed partial class LoginAttemptFilter : IFilter<LoginAttempt>
    {
    }
}
