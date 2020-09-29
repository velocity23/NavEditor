using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace NavEditor
{
    public class DirectorySearcher
    {
        private List<string> Directories { get; set; }

        private readonly string filename;

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

        public void IndexDir(string path, bool writefile = true, bool clearindex = false)
        {
            if (File.Exists(filename))
            {
                Directories = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(filename));
                return;
            }

            if (clearindex) Directories.Clear();
            var dirs = Directory.GetDirectories(path).ToList().Where(d => !d.EndsWith(".git") && !d.EndsWith("[-]")).ToList();
            Directories.AddRange(dirs.Where(d => File.Exists(d + @"\apt.dat")));
            
            foreach (var d in dirs)
            {
                IndexDir(d, false);
            }

            if (writefile)
            {
                File.Create(filename).Close();
                File.WriteAllText(filename, JsonConvert.SerializeObject(Directories, Formatting.Indented));
            }
        }
    }
}
