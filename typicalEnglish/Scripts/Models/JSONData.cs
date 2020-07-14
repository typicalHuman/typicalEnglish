using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typicalEnglish.Scripts.Models
{
    class JSONData
    {
        public static void Save(ObservableCollection<Deck> decks)
        {
            File.WriteAllText(@"C:\Users\HP\Desktop\info.json", JsonConvert.SerializeObject(decks, Formatting.Indented));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"C:\Users\HP\Desktop\info.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, decks);
            }
        }
    }
}
