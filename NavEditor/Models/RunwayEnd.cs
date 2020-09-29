using System;
using System.Collections.Generic;
using System.Text;

namespace NavEditor.Models
{
    public class RunwayEnd
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Ident { get; set; }

        public override string ToString()
        {
            return Ident;
        }
    }
}
