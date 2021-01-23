using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using NavEditor.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NavEditor
{
    public partial class MainWindow : Form
    {
        private Configuration Configuration { get; set; }
        private string AirportsFolder
        {
            get => Configuration.AirportsDir;
            set
            {
                Configuration.AirportsDir = value;
                var json = JsonConvert.SerializeObject(Configuration);
                File.WriteAllText(ConfigFilePath, json);
            }
        }
        private string NavigationFolder
        {
            get => Configuration.NavigationDir;
            set
            {
                Configuration.NavigationDir = value;
                var json = JsonConvert.SerializeObject(Configuration);
                File.WriteAllText(ConfigFilePath, json);
            }
        }

        private readonly string dataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\NavEditor";
        private const string indexFile = "airports.json";
        private const string configFile = "config.json";
        private string IndexFilePath { get => dataDir + @"\" + indexFile; }
        private string ConfigFilePath { get => dataDir + @"\" + configFile; }

        private List<Localizer> Localizers { get; set; }
        private List<Glideslope> Glideslopes { get; set; }
        private Glideslope CurrentGs { get; set; }
        private Localizer CurrentLoc { get; set; }
        private Airport CurrentApt { get; set; }

        private readonly Parser parser;
        private readonly DirectorySearcher searcher;

        public MainWindow()
        {
            InitializeComponent();
            ApproachPanel.Hide();
            parser = new Parser();
            searcher = new DirectorySearcher(IndexFilePath);
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }
            if (!File.Exists(IndexFilePath))
            {
                File.Create(IndexFilePath).Close();
                File.WriteAllText(IndexFilePath, "[]");
            }
            if (!File.Exists(ConfigFilePath))
            {
                File.Create(ConfigFilePath).Close();
                File.WriteAllText(ConfigFilePath, "{\"airportsDir\": null, \"navigationDir\": null}");
                Localizers = new List<Localizer>();
                Glideslopes = new List<Glideslope>();
                Configuration = new Configuration();
            }
            else
            {
                Configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigFilePath));

                if (string.IsNullOrEmpty(Configuration.NavigationDir))
                {
                    Localizers = new List<Localizer>();
                    Glideslopes = new List<Glideslope>();
                }
                else
                {
                    Localizers = JsonConvert.DeserializeObject<List<Localizer>>(File.ReadAllText(NavigationFolder + @"\LOC.json"));
                    Glideslopes = JsonConvert.DeserializeObject<List<Glideslope>>(File.ReadAllText(NavigationFolder + @"\Glideslope.json"));
                }
            }
        }

        private void AirportText_TextChanged(object sender, EventArgs e)
        {
            if ((AirportsFolder == null || NavigationFolder == null) && AirportText.Text != string.Empty)
            {
                MessageBox.Show("You must set the Airport and Navigation Folders first!", "NavEditor");
                AirportText.Text = string.Empty;
                return;
            }
            else if (!searcher.IsReady && AirportText.Text != string.Empty)
            {
                MessageBox.Show("The Airports are still Loading! Won't be too long.", "NavEditor");
                AirportText.Text = string.Empty;
                return;
            }
            ApproachPanel.Hide();
            var icao = AirportText.Text;
            var approaches = Localizers.Where(l => l.Airport == icao).ToList();

            ApproachSelect.Items.Clear();
            ApproachSelect.Items.AddRange(approaches.Select(a => new DropdownItem($"{a.Identifier} (Runway {a.Runway})", $"{a.Identifier}:{a.Airport}")).ToArray());
            ApproachSelect.Text = approaches.Count + " Approaches";
        }

        private void ApproachSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AirportsFolder == null || NavigationFolder == null)
            {
                MessageBox.Show("You must set the Airport and Navigation Folders first!", "NavEditor");
                AirportText.Text = string.Empty;
                return;
            }
            else if (!searcher.IsReady && AirportText.Text != string.Empty)
            {
                MessageBox.Show("The Airports are still Loading! Won't be too long.", "NavEditor");
                AirportText.Text = string.Empty;
                return;
            }
            ApproachPanel.Hide();
            var selected = (DropdownItem)ApproachSelect.SelectedItem;
            var ident = selected.Value.Split(":".ToCharArray())[0];
            var icao = selected.Value.Split(":".ToCharArray())[1];
            CurrentLoc = Localizers.FirstOrDefault(l => l.Identifier == ident && l.Airport == icao);
            CurrentGs = Glideslopes.FirstOrDefault(g => g.Identifier == ident && g.Airport == icao);


            if (CurrentGs == null) Glidepath.Hide(); else Glidepath.Show();
            var dir = searcher.SearchDir(AirportsFolder, icao);
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
            AppRwyBox.Items.Clear();
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
                CurrentLoc.Bearing = Math.Round(currentRwy.Bearing1, 3);
            }
            else
            {
                CurrentLoc.Bearing = Math.Round(currentRwy.Bearing2, 3);
            }

            if (CurrentGs != null)
            {
                CurrentGs.Elevation = CurrentApt.Elevation;
                CurrentGs.Frequency = (int)(AppFreqBox.Value * 1000);
                CurrentGs.Identifier = AppIdentBox.Text;
                CurrentGs.Latitude = selectedEnd.Latitude;
                CurrentGs.Longitude = selectedEnd.Longitude;
                CurrentGs.Runway = selectedEnd.Ident;
                CurrentGs.Bearing = CurrentLoc.Bearing;

                var slopeBearing = (CurrentGs.Bearing * 1000).ToString();
                if (slopeBearing.Split('.')[0].Length == 2) slopeBearing = $"0{slopeBearing}";
                CurrentGs.Slope = double.Parse(AppGpBox.Value.ToString() + slopeBearing);
            }

            var index = Localizers.IndexOf(Localizers.FirstOrDefault(l => l.Identifier == CurrentLoc.Identifier && l.Airport == CurrentApt.IcaoCode));
            Localizers[index] = CurrentLoc;
            if (CurrentGs != null)
            {
                var gsindex = Glideslopes.IndexOf(Glideslopes.FirstOrDefault(g => g.Identifier == CurrentGs.Identifier && g.Airport == CurrentApt.IcaoCode));
                Glideslopes[gsindex] = CurrentGs;
            }

            var locJson = File.ReadAllText(NavigationFolder + @"\LOC.json");
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
            File.WriteAllText(NavigationFolder + @"\LOC.json", locJson);

            if (CurrentGs != null)
            {
                var gsJson = File.ReadAllText(NavigationFolder + @"\Glideslope.json");
                
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
                File.WriteAllText(NavigationFolder + @"\Glideslope.json", gsJson);
            }

            MessageBox.Show("Saved!", "NavEditor");
        }

        private async void AptFoldBtn_Click(object sender, EventArgs e)
        {
            var result = aptDirDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(aptDirDialog.SelectedPath))
            {
                AirportsFolder = aptDirDialog.SelectedPath;
                AptDirBtn.Enabled = false;
                AirportText.Enabled = false;
                ApproachSelect.Enabled = false;
                MessageLabel.Text = "Loading Airports...";
                await searcher.IndexDir(AirportsFolder, forceindex: true);
                MessageLabel.Text = "Welcome to NavEditor!";
                MessageBox.Show("Success!", "NavEditor");
                AptDirBtn.Enabled = true;
                AirportText.Enabled = true;
                ApproachSelect.Enabled = true;
            }
        }

        private void NavDirBtn_Click(object sender, EventArgs e)
        {
            NavDirBtn.Enabled = false;
            var result = navDirDialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(navDirDialog.SelectedPath))
            {
                var files = Directory.GetFiles(navDirDialog.SelectedPath).Select(f => f.ToLower());
                if (!files.Any(f => f.EndsWith("loc.json")) || !files.Any(f => f.EndsWith("glideslope.json")))
                {
                    MessageBox.Show("Folder Must contain LOC.json and Glideslope.json files", "NavEditor");
                    return;
                }
                NavigationFolder = navDirDialog.SelectedPath;
                NavDirBtn.Enabled = true;
                MessageLabel.Text = "Loading Approaches...";
                Localizers = JsonConvert.DeserializeObject<List<Localizer>>(File.ReadAllText(NavigationFolder + @"\LOC.json"));
                Glideslopes = JsonConvert.DeserializeObject<List<Glideslope>>(File.ReadAllText(NavigationFolder + @"\Glideslope.json"));
                MessageLabel.Text = "Welcome to NavEditor!";
                MessageBox.Show("Success!", "NavEditor");
            }
        }

        private async void MainWindow_Shown(object sender, EventArgs e)
        {
            if (File.ReadAllText(IndexFilePath) == "[]" && AirportsFolder != null)
            {
                AirportText.Enabled = false;
                ApproachSelect.Enabled = false;
                RefreshAirports.Enabled = false;
                MessageLabel.Text = "Loading Airports...";
                await searcher.IndexDir(AirportsFolder, forceindex: true);
                MessageLabel.Text = "Welcome to NavEditor!";
                AirportText.Focus();
                AirportText.Enabled = true;
                ApproachSelect.Enabled = true;
                RefreshAirports.Enabled = true;
                return;
            }

            AirportText.Enabled = false;
            ApproachSelect.Enabled = false;
            RefreshAirports.Enabled = false;
            MessageLabel.Text = "Loading Airports...";
            await searcher.IndexDir(AirportsFolder);
            MessageLabel.Text = "Welcome to NavEditor!";
            RefreshAirports.Enabled = true;
            AirportText.Enabled = true;
            AirportText.Focus();
            ApproachSelect.Enabled = true;
        }

        private async void RefreshAirports_Click(object sender, EventArgs e)
        {
            AirportText.Text = string.Empty;
            AirportText.Enabled = false;
            ApproachSelect.Enabled = false;
            RefreshAirports.Enabled = false;
            MessageLabel.Text = "Loading Airports...";
            await searcher.IndexDir(AirportsFolder, forceindex: true);
            AirportText.Enabled = true;
            ApproachSelect.Enabled = true;
            RefreshAirports.Enabled = true;
            MessageLabel.Text = "Welcome to NavEditor!";
            MessageBox.Show("Success!", "NavEditor");
        }

        private void RefreshNav_Click(object sender, EventArgs e)
        {
            RefreshNav.Enabled = false;
            MessageLabel.Text = "Loading Approaches...";
            Localizers = JsonConvert.DeserializeObject<List<Localizer>>(File.ReadAllText(NavigationFolder + @"\LOC.json"));
            Glideslopes = JsonConvert.DeserializeObject<List<Glideslope>>(File.ReadAllText(NavigationFolder + @"\Glideslope.json"));
            MessageLabel.Text = "Welcome to NavEditor!";
            RefreshNav.Enabled = true;
            MessageBox.Show("Success!", "NavEditor");
        }

        private void ViewCredits_Click(object sender, EventArgs e)
        {
            var creditsText = "NavEditor is Open Source Software Under the Apache 2.0 License\r\n\r\n" +
                "Originally Created by Kai Malcolm (@Velocity23) for the IFAET Navigation Team\r\n\r\n" +
                "Thanks to Cameron for his feedback and suggestions\r\n\r\n" +
                "Also thanks to the whole Navigation Team for giving feedback on various bits and pieces.\r\n\r\n" +
                "Design inspired by LiveFlight Connect - connect.liveflightapp.com";
            MessageBox.Show(creditsText, "Credits - NavEditor", MessageBoxButtons.OK);
        }
    }
}
