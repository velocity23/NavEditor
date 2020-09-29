using System;
using System.Collections.Generic;
using System.Text;

namespace NavEditor.Models
{
    public class RampStart
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Heading { get; set; }
        public string GateType { get; set; }
        public string Name { get; set; }
        public int LineDefined { get; set; }
        public string LatLonHeading
        {
            get
            {
                return Latitude + ", " + Longitude + "@" + Heading;
            }
        }
    }
}
