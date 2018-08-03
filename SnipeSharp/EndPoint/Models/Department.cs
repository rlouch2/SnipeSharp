using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [PathSegment("departments")]
    public sealed class Department : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; protected set; }

        [Field("name", true, required: true)]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("company", "company_id", converter: CommonModelConverter)]
        public Company Company { get; set; }

        [Field("manager", "manager_id", converter: CommonModelConverter)]
        public User Manager { get; set; }

        [Field("location", "location_id", converter: CommonModelConverter)]
        public Location Location { get; set; }

        [Field(null, "user_id")]
        public User TODO_WHATS_THIS_User { get; set; } // TODO: this is a field in the DB, is it set to the creator's id?

        [Field("notes", true)]
        public string Notes { get; set; }

        [Field("users_count")]
        public int UsersCount { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; protected set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; protected set; }
        
        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}
