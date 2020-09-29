using NavEditor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace NavEditor
{
    public class Parser
    {
        public List<Airport> Airports { get; set; }

        public Parser()
        {
            Airports = new List<Airport>();
        }

        /// <summary>
        /// Parse an apt.dat file and check for errors
        /// </summary>
        /// <param name="path">The path to the apt.dat</param>
        /// <returns>A Parsed Airport</returns>
        public void ParseAirport(string path)
        {
            const string AIRPORT_PREFIX = "1";
            const string SEAPL_PREFIX = "16";
            const string HELO_PREFIX = "17";
            const string GATE_PREFIX = "1300";
            const string RUNWAY_PREFIX = "100";
            var lines = File.ReadAllLines(path);

            var currentAirport = new Airport();

            for (var i=0;i<lines.Length;i++)
            {
                var l = lines[i];
                if (string.IsNullOrWhiteSpace(l)) continue;

                var segments = l.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

                switch (segments[0])
                {
                    case AIRPORT_PREFIX:
                        var newApt = new Airport
                        {
                            IcaoCode = segments[4],
                            Elevation = int.Parse(segments[1]),
                            RampStarts = new List<RampStart>(),
                            Runways = new List<Runway>(),
                            FilePath = path,
                        };
                        currentAirport = newApt;
                        break;
                    case SEAPL_PREFIX:
                        return;
                    case HELO_PREFIX:
                        return;
                    case RUNWAY_PREFIX:
                        if (currentAirport == new Airport())
                        {
                            throw new Exception("Invalid apt.dat - Runway before Airport");
                        }
                        currentAirport.Runways.Add(new Runway
                        {
                            End1 = new RunwayEnd
                            {
                                Latitude = double.Parse(segments[9]),
                                Longitude = double.Parse(segments[10]),
                                Ident = segments[8],
                            },
                            End2 = new RunwayEnd
                            {
                                Latitude = double.Parse(segments[18]),
                                Longitude = double.Parse(segments[19]),
                                Ident = segments[17],
                            },
                        });
                        break;
                    case GATE_PREFIX:
                        var name = "";
                        for (int j = 0; j < segments.Length; j++)
                        {
                            if (j == 6)
                            {
                                name = segments[6];
                            }
                            else
                            {
                                name += " " + segments[j];
                            }
                        }
                        var newRs = new RampStart
                        {
                            Latitude = double.Parse(segments[1]),
                            Longitude = double.Parse(segments[2]),
                            Heading = double.Parse(segments[3]),
                            GateType = segments[4],
                            Name = name,
                            LineDefined = i + 1
                        };

                        currentAirport.RampStarts.Add(newRs);
                        break;
                }
            }

            if (currentAirport.IcaoCode != null)
            {
                Airports.Add(currentAirport);
            }
        }

        public static double DistanceBetween(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            // Convert to Meters
            dist *= 1609.344;

            return dist;
        }
    }
}
