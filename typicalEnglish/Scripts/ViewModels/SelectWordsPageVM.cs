using System.Collections.ObjectModel;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// View model for SelectWordsPage
    /// </summary>
    public class SelectWordsPageVM: BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializing words.
        /// </summary>
        /// <param name="words">Words for exam.</param>
        public SelectWordsPageVM(ObservableCollection<Word> words)
        {
            Words = words;
        }

        #endregion

        #region Methods

        public ObservableCollection<Word> GetSelectedWords()
        {
            ObservableCollection<Word> selectedWords = new ObservableCollection<Word>();
            foreach (Word w in Words)
                if (w.IsSelected)
                    selectedWords.Add(w);
            return selectedWords;
        }

        #endregion

        #region Properties

        public ObservableCollection<Word> Words { get; set; }

        #endregion

        #region Commands

        #region SelectionChangedCommand

        private RelayCommand selectionChangedCommand;
        /// <summary>
        /// Word selection changed.
        /// It needs for excluding empty value of <see cref="Words"./>
        /// </summary>
        public RelayCommand SelectionChangedCommand
        {
            get => selectionChangedCommand ?? (selectionChangedCommand = new RelayCommand(obj =>
            {
                App.TestPageVM.IsEmpty = GetSelectedWords().Count == 0;
            }));
        }


        #endregion

        #endregion
    }
}
