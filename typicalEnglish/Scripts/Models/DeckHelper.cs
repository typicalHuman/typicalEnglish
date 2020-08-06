using System.Collections.ObjectModel;

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
    }
}
