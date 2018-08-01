using System;
using System.Collections.Generic;
using SnipeSharp.Serialization;
using static SnipeSharp.Serialization.FieldConverter;

namespace SnipeSharp.EndPoint.Models
{
    [EndPointInformation("departments", "")]
    public class Department : CommonEndPointModel
    {
        [Field("id")]
        public override int Id { get; set; }

        [Field("name")]
        public override string Name { get; set; }

        [Field("image")]
        public Uri ImageUri { get; set; }

        [Field("company")]
        public Company Company { get; set; }

        [Field("manager")]
        public User Manager { get; set; }

        [Field("location")]
        public Location Location { get; set; }

        [Field("users_count")]
        public int UsersCount { get; set; }

        [Field("created_at", converter: DateTimeConverter)]
        public override DateTime? CreatedAt { get; set; }

        [Field("updated_at", converter: DateTimeConverter)]
        public override DateTime? UpdatedAt { get; set; }
        
        [Field("available_actions")]
        public Dictionary<AvailableAction, bool> AvailableActions { get; set; }
    }
}