using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZippopotamousAPI
{
   public class Places : Location
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }

        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }

    }
}
