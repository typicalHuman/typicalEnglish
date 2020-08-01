using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for de/serialization of json data.
    /// </summary>
    class JSONData
    {
        private const string FILE_NAME = "decks.json";

        /// <summary>
        /// Save to json file.
        /// </summary>
        /// <param name="decks"> Decks that should be saved.</param>
        public static void Save(ObservableCollection<Deck> decks)
        {
            File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(decks));

            using (StreamWriter file = File.CreateText(FILE_NAME))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, decks);
            }
        }

        /// <summary>
        /// Deserialize decks data.
        /// </summary>
        /// <returns>Saved decks.</returns>
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