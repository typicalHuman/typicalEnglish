using System.Collections.Generic;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for work with words.
    /// </summary>
    class WordHelper
    {
        /// <param name="word">Word to check.</param>
        /// <returns>Is already exists in another decks.</returns>
        public static bool IsWordExists(Word word)
        {
            if (word.Spelling != null && word.Spelling.Length > 0)//check emptiness of spelling
            {
                List<Word> words = DeckHelper.GetWordsInDecks(App.DecksVM.Decks);
                for (int i = 0; i < words.Count; i++)
                {
                    if (words[i] != word && word.Spelling == words[i].Spelling)
                        return true;
                }
                return false;
            }
            return false;
        }

    }
}
