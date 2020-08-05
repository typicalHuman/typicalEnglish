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
        private const string CONFIG_FILE_NAME = "options.json";

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

        /// <summary>
        /// Save dark mode option.
        /// </summary>
        public static void SaveConfig(bool isDarkMode)
        {
            File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(isDarkMode));

            using (StreamWriter file = File.CreateText(CONFIG_FILE_NAME))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, isDarkMode);
            }
        }

        /// Deserialize options data.
        /// </summary>
        /// <returns>Is dark mode.</returns>
        public static bool GetConfig()
        {
            if (File.Exists(CONFIG_FILE_NAME))
            {
                string jsonString = File.ReadAllText(CONFIG_FILE_NAME);
                return JsonConvert.DeserializeObject<bool>(jsonString);
            }
            return false;
        }
    }
}