using System.Collections.Generic;
using System.Collections.ObjectModel;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// View model for DeckCombinePage.
    /// </summary>
    public class DecksCombineVM: BaseViewModel
    {
        #region Methods

        private void RemoveCombinedDecks()
        {
            for(int i = 0; i < decks.Count; i++)
            {
                App.DecksVM.Decks.Remove(decks[i]);
            }
            decks = new ObservableCollection<Deck>();
        }

        private Deck GetNewDeck(List<Word> words)
        {
            Deck newDeck = new Deck();
            for (int i = 0; i < words.Count; i++)
                newDeck.Words.Add(words[i]);
            return newDeck;
        }

        private void SetDecksSelections()
        {
            DeckHelper.SetDecksSelections(decks);
            IsCombineEnabled = decks.Count > 1;
        }

        #endregion

        #region Commands

        #region BackCommand
        private RelayCommand backCommand;
        /// <summary>
        /// Back to options page.
        /// </summary>
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate(Paths.OPTIONS_PAGE);
            }));
        }
        #endregion

        #region CheckedChangeCommand
        private RelayCommand checkedChangeCommand;
        public RelayCommand CheckedChangeCommand
        {
            get => checkedChangeCommand ?? (checkedChangeCommand = new RelayCommand(obj =>
            {
                SetDecksSelections();
            }));
        }
        #endregion

        #region CombineDecksCommand
        private RelayCommand combineDecksCommand;
        public RelayCommand CombineDecksCommand
        {
            get => combineDecksCommand ?? (combineDecksCommand = new RelayCommand(obj =>
            {
                List<Word> words = DeckHelper.GetWordsInDecks(decks);
                RemoveCombinedDecks();
                Deck newDeck = GetNewDeck(words);
                App.DecksVM.Decks.Add(newDeck);
                SetDecksSelections();
            }));
        }
        #endregion


        #endregion

        #region Properties

        private ObservableCollection<Deck> decks { get; set; } = new ObservableCollection<Deck>();

        #region IsCombineEnabled

        private bool isCombineEnabled;
        /// <summary>
        /// Is more than 2 selected decks.
        /// </summary>
        public bool IsCombineEnabled
        {
            get => isCombineEnabled;
            set
            {
                isCombineEnabled = value;
                OnPropertyChanged("IsCombineEnabled");
            }
        }

        #endregion

        #endregion
    }
}
