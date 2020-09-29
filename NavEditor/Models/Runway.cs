using System;
using System.Collections.Generic;
using System.Text;

namespace NavEditor.Models
{
    public class Runway
    {
        public RunwayEnd End1 { get; set; }
        public RunwayEnd End2 { get; set; }

        public double Bearing1
        {
            get => Geometry.DegreeBearing(End1.Latitude, End1.Longitude, End2.Latitude, End2.Longitude);
        }

        public double Bearing2
        {
            get => Geometry.DegreeBearing(End2.Latitude, End2.Longitude, End1.Latitude, End1.Longitude);
        }

        public List<RunwayEnd> Ends
        {
            get
            {
                return new List<RunwayEnd>
                {
                    End1,
                    End2,
                };
            }
        }
        public string Identifier
        {
            get
            {
                return End1.Ident + "/" + End2.Ident;
            }
        }
    }
}
