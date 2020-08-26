using System.Collections.ObjectModel;
using typicalEnglish.Scripts.Models;

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
            App.TestPageVM.IsEmpty = GetSelectedWords().Count == 0;
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

        #region IsEnglish
        private bool isEnglish = false;
        /// <summary>
        /// Indicator of test language.
        /// </summary>
        public bool IsEnglish
        {
            get => isEnglish;
            set
            {
                isEnglish = value;
                OnPropertyChanged("IsEnglish");
            }
        }

        #endregion

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
