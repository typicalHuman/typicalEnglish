using System.Collections.ObjectModel;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Decks choosing view model.
    /// </summary>
    public class DecksPageVM: BaseViewModel
    {
        #region Constructor
        /// <summary>
        /// Set decks to choose from json data.
        /// </summary>
        public DecksPageVM()
        {
            Decks = JSONData.GetSavedDecks();
        }
        #endregion

        #region Properties

        public ObservableCollection<Deck> Decks { get; set; }

        #endregion

        #region Commands

        #region AddDeckCommand
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get => addCommand ?? (addCommand = new RelayCommand(obj =>
            {
                Decks.Insert(0, new Deck());
            }));
        }
        #endregion

        #region DeleteDeckCommand

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
            {
                string result = ConfirmWindow.OpenConfirmWindow();
                if(result.ToString() == "Yes")
                   Decks.Remove(obj as Deck);
            }));
        }

        #endregion

        #region OpenDeckCommand
        private RelayCommand openDeckCommand;
        /// <summary>
        /// Open words editing page.
        /// </summary>
        public RelayCommand OpenDeckCommand
        {
            get => openDeckCommand ?? (openDeckCommand = new RelayCommand(obj =>
            {
                Deck deck = obj as Deck;
                if (deck != null)
                {
                    App.DeckVM = new DeckPageVM(deck.Words);
                    App.MainVM.Navigate(Paths.DECK_PAGE);
                }
            }));
        }
        #endregion

        #region OpenDeckCustomizationCommand
        private RelayCommand openDeckCustomizationCommand;
        public RelayCommand OpenDeckCustomizationCommand
        {
            get => openDeckCustomizationCommand ?? (openDeckCustomizationCommand = new RelayCommand(obj =>
            {
                Deck deck = obj as Deck;
                if (deck != null)
                {
                    App.DeckCustomVM = new DeckCustomPageVM(deck);
                    App.MainVM.Navigate(Paths.DECKS_CUSTOMIZATION);
                }
            }));
        }
        #endregion

        #endregion
    }
}
