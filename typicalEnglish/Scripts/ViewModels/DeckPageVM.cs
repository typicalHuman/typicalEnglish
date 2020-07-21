using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DeckPageVM: INotifyPropertyChanged
    {

        #region Constructor


        public DeckPageVM(ObservableCollection<Word> words)
        {
            Words = words;
        }

        #endregion

        #region Commands

        #region BackCommand
        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate("Scripts/Views/DecksPage.xaml");
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

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
