using System.Collections.Generic;
using System.Collections.ObjectModel;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for additional deck manipulation functions.
    /// </summary>
    class DeckHelper
    {
        /// <summary>
        /// Set decks selections from App.DecksVM.Decks.
        /// </summary>
        public static void SetDecksSelections(ObservableCollection<Deck> decks)
        {
            foreach (Deck d in App.DecksVM.Decks)
            {
                if (!decks.Contains(d) && d.IsSelected)
                    decks.Add(d);
                else if (decks.Contains(d) && !d.IsSelected)
                    decks.Remove(d);
            }
        }

        /// <summary>
        /// Get all words in <paramref name="decks"/>.
        /// </summary>
        /// <returns>List of words.</returns>
        public static List<Word> GetWordsInDecks(ObservableCollection<Deck> decks)
        {
            List<Word> words = new List<Word>();
            foreach (Deck d in decks)
            {
                foreach (Word w in d.Words)
                {
                    words.Add(w);
                }
            }
            return words;
        }
    }
}
