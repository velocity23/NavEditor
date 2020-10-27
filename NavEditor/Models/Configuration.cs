using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavEditor.Models
{
    public class Configuration
    {
        [JsonProperty("airportsDir")]
        public string AirportsDir { get; set; }

        [JsonProperty("navigationDir")]
        public string NavigationDir { get; set; }
    }
}
