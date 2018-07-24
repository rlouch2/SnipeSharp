using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace SnipeSharp.Common
{
    public class Message
    {
        [DeserializeAs(Name = "name")]
        public List<string> Name { get; set; }

        [DeserializeAs(Name = "general")]
        public List<string> General { get; set; }
    }
}
