using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnipeSharp.Common;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SnipeSharp.Endpoints.Models
{
    public class CustomField
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "db_column_name")]
        public string DbColumnName { get; set; }

        [DeserializeAs(Name = "format")]
        public string Format { get; set; }

        [DeserializeAs(Name = "required")]
        public int? Required { get; set; }

        [DeserializeAs(Name = "created_at")]
        public ResponseDate CreatedAt { get; set; }

        [DeserializeAs(Name = "updated_at")]
        public ResponseDate UpdatedAt { get; set; }
    }
}

