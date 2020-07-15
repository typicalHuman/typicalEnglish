using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace typicalEnglish.Scripts.Models
{
    class JSONData
    {
        private const string FILE_NAME = "decks.json";

        public static void Save(ObservableCollection<Deck> decks)
        {
            File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(decks));

            using (StreamWriter file = File.CreateText(FILE_NAME))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, decks);
            }
        }

        public static ObservableCollection<Deck> GetSavedDecks()
        {
            if (File.Exists(FILE_NAME))
            {
                string jsonString = File.ReadAllText(FILE_NAME);
                return JsonConvert.DeserializeObject<ObservableCollection<Deck>>(jsonString);
            }
            return new ObservableCollection<Deck>();
        }
    }
}