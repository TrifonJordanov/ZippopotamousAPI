using System.Text.Json.Serialization;

namespace ZippopotamousAPI
{
    public class Location
    {
        [JsonPropertyName("post code")]
        public string postCode { get; set; }
       
        public string country { get; set; }
        
        [JsonPropertyName("country abbreviation")]
        public string CountryАbbreviation { get; set; }
        [JsonPropertyName("places")]
        public Places[] Places { get; set; }
    }
}
