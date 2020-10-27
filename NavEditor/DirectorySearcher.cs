using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace NavEditor
{
    public class DirectorySearcher
    {
        private List<string> Directories { get; set; }

        private readonly string filename;

        public bool IsReady
        {
            get => Directories.Count != 0;
        }

        public DirectorySearcher(string indexfile)
        {
            Directories = new List<string>();
            filename = indexfile;
        }
        
        public string SearchDir(string path, string search, bool forcesearch = false)
        {
            if (forcesearch || Directories.Count == 0)
            {
                var dirs = Directory.GetDirectories(path).ToList().Where(d => d != ".git");

                foreach (var d in dirs)
                {
                    Directories.Add(d);
                    if (d.EndsWith($"\\{search}"))
                    {
                        return d;
                    }
                    var ret = SearchDir(d, search, true);
                    if (ret != null) return ret;
                }

                return null;
            }
            else
            {
                return Directories.FirstOrDefault(d => d.EndsWith($"\\{search}"));
            }
        }

        public async Task IndexDir(string path, bool writefile = true, bool clearindex = false, bool forceindex = false)
        {
            await Task.Run(async () =>
            {
                if (File.Exists(filename) && !forceindex)
                {
                    Directories = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(filename));
                    return;
                }

                if (clearindex || (forceindex && writefile)) Directories.Clear();
                var dirs = Directory.GetDirectories(path).ToList().Where(d => !d.EndsWith(".git") && !d.EndsWith("[-]")).ToList();
                var toAdd = dirs.Where(d => File.Exists(d + @"\apt.dat"));
                Directories.AddRange(toAdd);

                foreach (var d in dirs)
                {
                    await IndexDir(d, false, forceindex: true);
                }

                if (writefile)
                {
                    if (!File.Exists(filename)) File.Create(filename).Close();
                    File.WriteAllText(filename, JsonConvert.SerializeObject(Directories));
                }
            });
        }
    }
}
