using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace SnipeSharp.Common
{
    public class Date
    {
        [DeserializeAs(Name = "formatted")]
        public string Formatted { get; set; }

        [DeserializeAs(Name = "date")]
        public string DateObj { get; set; }
    }
}
