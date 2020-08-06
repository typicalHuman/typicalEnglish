using System.Collections.ObjectModel;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// View model for words editing.
    /// </summary>
    public class DeckPageVM: BaseViewModel
    {
        #region Constructor
        /// <param name="words">Words which will edit.</param>
        public DeckPageVM(ObservableCollection<Word> words)
        {
            Words = words;
        }

        #endregion

        #region Commands

        #region BackCommand
        private RelayCommand backCommand;
        /// <summary>
        /// Back to decks choosing page.
        /// </summary>
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate(Paths.DECKS_PAGE);
            }));
        }
        #endregion

        #region AddWordCommand
        private RelayCommand addWordCommand;
        public RelayCommand AddWordCommand
        {
            get => addWordCommand ?? (addWordCommand = new RelayCommand(obj =>
            {
                Words.Insert(0, new Word());
            }));
        }
        #endregion

        #region DeleteWordCommand

        private RelayCommand deleteWordCommand;
        public RelayCommand DeleteWordCommand
        {
            get => deleteWordCommand ?? (deleteWordCommand = new RelayCommand(obj =>
            {
                Words.Remove(obj as Word);
            }));
        }

        #endregion

        #endregion

        #region Properties

        public ObservableCollection<Word> Words { get; set; }

        #endregion
    }
}
