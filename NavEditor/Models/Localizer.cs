using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavEditor.Models
{
    public class Localizer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("airportICAO")]
        public string Airport { get; set; }
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
        [JsonProperty("associatedRunwayNumber")]
        public string Runway { get; set; }
        [JsonProperty("frequency")]
        public int Frequency { get; set; }
        [JsonProperty("elevation")]
        public int Elevation { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("bearing")]
        public double Bearing { get; set; }
        [JsonProperty("receptionRange")]
        public int ReceptionRange { get; set; }
        [JsonProperty("type")]
        public int Type { get; set; }
    }
}
