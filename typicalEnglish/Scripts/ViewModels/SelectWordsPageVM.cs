using System.Collections.ObjectModel;

namespace typicalEnglish.Scripts.ViewModels
{
    public class SelectWordsPageVM: BaseViewModel
    {
        #region Constructor

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
