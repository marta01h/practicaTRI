using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Proverkka
{
    internal class SaveLoad
    {
        private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Note.json");

        public static List<Note> Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<Note>>(json);
            }
            else
            {
                return new List<Note>();
            }
        }

        public static void Save(List<Note> notes)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(FilePath, json);
        }
    }
}
