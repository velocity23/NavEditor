using System;
using System.Collections.Generic;
using System.Text;

namespace NavEditor.Models
{
    public class Airport
    {
        public string FilePath { get; set; }
        public string IcaoCode { get; set; }
        public int Elevation { get; set; }
        public List<RampStart> RampStarts { get; set; }
        public List<Runway> Runways { get; set; }
    }
}
