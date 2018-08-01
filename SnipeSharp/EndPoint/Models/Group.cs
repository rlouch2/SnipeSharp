using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("groups", "")]
    public class Group : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("permissions", converter: PermissionsConverter)]
        public Dictionary<string, bool> Permissions { get; set; }

        [Field("users_count")]
        public int? UsersCount { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }

        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}