using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using NavEditor.Models;
using Newtonsoft.Json;

namespace NavEditor
{
    public partial class Form1 : Form
    {
        private const string airportsFolder = @"D:\Airport Editing\Airports";
        private const string navigationFolder = @"D:\Airport Editing\Navigation Fork";
        private const string directoryIndex = @"D:\Airport Editing\AirportIndex.json";

        private List<Localizer> Localizers { get; set; }
        private List<Glideslope> Glideslopes { get; set; }
        private Glideslope CurrentGs { get; set; }
        private Localizer CurrentLoc { get; set; }
        private Airport CurrentApt { get; set; }

        private readonly Parser parser;
        private readonly DirectorySearcher searcher;

        public Form1()
        {
            InitializeComponent();
            ApproachPanel.Hide();
            Localizers = JsonConvert.DeserializeObject<List<Localizer>>(File.ReadAllText(navigationFolder + @"\LOC.json"));
            Glideslopes = JsonConvert.DeserializeObject<List<Glideslope>>(File.ReadAllText(navigationFolder + @"\Glideslope.json"));
            parser = new Parser();
            searcher = new DirectorySearcher(directoryIndex);
            searcher.IndexDir(airportsFolder);
        }

        private void AirportText_TextChanged(object sender, EventArgs e)
        {
            ApproachPanel.Hide();
            var icao = AirportText.Text;
            var approaches = Localizers.Where(l => l.Airport == icao).ToList();

            ApproachSelect.Items.Clear();
            ApproachSelect.Items.AddRange(approaches.Select(a => new DropdownItem($"{a.Identifier} (Runway {a.Runway})", $"{a.Identifier}:{a.Airport}")).ToArray());
            ApproachSelect.Text = approaches.Count + " Approaches";
        }

        private void ApproachSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApproachPanel.Hide();
            var selected = (DropdownItem)ApproachSelect.SelectedItem;
            var ident = selected.Value.Split(":".ToCharArray())[0];
            var icao = selected.Value.Split(":".ToCharArray())[1];
            CurrentLoc = Localizers.FirstOrDefault(l => l.Identifier == ident && l.Airport == icao);
            CurrentGs = Glideslopes.FirstOrDefault(g => g.Identifier == ident && g.Airport == icao);


            if (CurrentGs == null) Glidepath.Hide(); else Glidepath.Show();
            var dir = searcher.SearchDir(airportsFolder, icao);
            parser.ParseAirport(dir + @"\apt.dat");
            CurrentApt = parser.Airports[0];
            parser.Airports.Clear();

            AppIdentBox.Text = ident;
            AppFreqBox.Value = (decimal)CurrentLoc.Frequency / 1000;
            var runwayends = new List<RunwayEnd>();
            foreach (var r in CurrentApt.Runways)
            {
                runwayends.AddRange(r.Ends);
            }
            AppRwyBox.Items.AddRange(runwayends.ToArray());
            AppRwyBox.SelectedItem = runwayends.FirstOrDefault(re => re.Ident == CurrentLoc.Runway);
            
            try
            {
                if (CurrentGs != null) AppGpBox.Value = decimal.Parse(CurrentGs.Slope.ToString().Substring(0, 4));
            }
            catch (ArgumentOutOfRangeException)
            {
                if (CurrentGs != null) AppGpBox.Value = decimal.Parse(CurrentGs.Slope.ToString());
            }

            ApproachPanel.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var selectedEnd = (RunwayEnd)AppRwyBox.SelectedItem;
            var tmpIdent = CurrentLoc.Identifier;
            CurrentLoc.Elevation = CurrentApt.Elevation;
            CurrentLoc.Frequency = (int)(AppFreqBox.Value * 1000);
            CurrentLoc.Identifier = AppIdentBox.Text;
            CurrentLoc.Latitude = Math.Round(selectedEnd.Latitude, 6);
            CurrentLoc.Longitude = Math.Round(selectedEnd.Longitude, 6);
            CurrentLoc.Runway = selectedEnd.Ident;
            
            var currentRwy = CurrentApt.Runways.FirstOrDefault(r => r.Ends.Contains(selectedEnd));
            if (currentRwy.End1 == selectedEnd)
            {
                CurrentLoc.Bearing = Math.Round(currentRwy.Bearing1, 2);
            }
            else
            {
                CurrentLoc.Bearing = Math.Round(currentRwy.Bearing2, 2);
            }

            if (CurrentGs != null)
            {
                CurrentGs.Elevation = CurrentApt.Elevation;
                CurrentGs.Frequency = (int)(AppFreqBox.Value * 1000);
                CurrentGs.Identifier = AppIdentBox.Text;
                CurrentGs.Latitude = Math.Round(selectedEnd.Latitude, 6);
                CurrentGs.Longitude = Math.Round(selectedEnd.Longitude, 6);
                CurrentGs.Runway = selectedEnd.Ident;
                CurrentGs.Bearing = CurrentLoc.Bearing;

                var slopeBearing = (CurrentGs.Bearing * 1000).ToString();
                if (slopeBearing.Length == 5) slopeBearing = "0" + slopeBearing;
                CurrentGs.Slope = double.Parse(AppGpBox.Value.ToString() + slopeBearing);
            }

            var index = Localizers.IndexOf(Localizers.FirstOrDefault(l => l.Identifier == CurrentLoc.Identifier && l.Airport == CurrentApt.IcaoCode));
            Localizers[index] = CurrentLoc;
            if (CurrentGs != null)
            {
                var gsindex = Glideslopes.IndexOf(Glideslopes.FirstOrDefault(g => g.Identifier == CurrentGs.Identifier && g.Airport == CurrentApt.IcaoCode));
                Glideslopes[gsindex] = CurrentGs;
            }

            var locJson = File.ReadAllText(navigationFolder + @"\LOC.json");
            var locpattern = $"\"name\": \".+\",\\s+\"airportICAO\": \"{CurrentApt.IcaoCode}\",\\s+\"identifier\": \"{tmpIdent}\",\\s+\"associatedRunwayNumber\": \".+\",\\s+\"frequency\": .+,\\s+\"elevation\": .+,\\s+\"latitude\": .+,\\s+\"longitude\": .+,\\s+\"bearing\": .+,\\s+\"receptionRange\": .+,\\s+\"type\": .+";
            var locreplace = $"\"name\": \"{CurrentLoc.Name}\","
                             + $"\r\n   \"airportICAO\": \"{CurrentLoc.Airport}\","
                             + $"\r\n   \"identifier\": \"{CurrentLoc.Identifier}\","
                             + $"\r\n   \"associatedRunwayNumber\": \"{CurrentLoc.Runway}\","
                             + $"\r\n   \"frequency\": {CurrentLoc.Frequency},"
                             + $"\r\n   \"elevation\": {CurrentLoc.Elevation},"
                             + $"\r\n   \"latitude\": {CurrentLoc.Latitude},"
                             + $"\r\n   \"longitude\": {CurrentLoc.Longitude},"
                             + $"\r\n   \"bearing\": {CurrentLoc.Bearing},"
                             + $"\r\n   \"receptionRange\": {CurrentLoc.ReceptionRange},"
                             + $"\r\n   \"type\": {CurrentLoc.Type}";

            locJson = Regex.Replace(locJson, locpattern, locreplace, RegexOptions.IgnoreCase);
            File.WriteAllText(navigationFolder + @"\LOC.json", locJson);

            if (CurrentGs != null)
            {
                var gsJson = File.ReadAllText(navigationFolder + @"\Glideslope.json");
                
                var gspattern = $"\"name\": \".+\",\\s+\"airportICAO\": \"{CurrentApt.IcaoCode}\",\\s+\"identifier\": \"{tmpIdent}\",\\s+\"associatedRunwayNumber\": \".+\",\\s+\"frequency\": .+,\\s+\"elevation\": .+,\\s+\"latitude\": .+,\\s+\"longitude\": .+,\\s+\"bearing\": .+,\\s+\"glideslope\": .+,\\s+\"receptionRange\": .+";
                var gsreplace = $"\"name\": \"{CurrentGs.Name}\","
                                + $"\r\n   \"airportICAO\": \"{CurrentGs.Airport}\","
                                + $"\r\n   \"identifier\": \"{CurrentGs.Identifier}\","
                                + $"\r\n   \"associatedRunwayNumber\": \"{CurrentGs.Runway}\","
                                + $"\r\n   \"frequency\": {CurrentGs.Frequency},"
                                + $"\r\n   \"elevation\": {CurrentGs.Elevation},"
                                + $"\r\n   \"latitude\": {CurrentGs.Latitude},"
                                + $"\r\n   \"longitude\": {CurrentGs.Longitude},"
                                + $"\r\n   \"bearing\": {CurrentGs.Bearing},"
                                + $"\r\n   \"glideslope\": {CurrentGs.Slope},"
                                + $"\r\n   \"receptionRange\": {CurrentGs.ReceptionRange}";

                gsJson = Regex.Replace(gsJson, gspattern, gsreplace, RegexOptions.IgnoreCase);
                File.WriteAllText(navigationFolder + @"\Glideslope.json", gsJson);
            }

            MessageBox.Show("Saved!", "NavEditor");
        }
    }
}
