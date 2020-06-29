using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    public class Deck: INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();

        #region ImageSource

        private string imageSource;
        public string ImageSource
        {
            get => imageSource;
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        #endregion

        #region Name

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        #endregion

        #region WordsCount

        private int wordsCount;
        public int WordsCount
        {
            get => Words.Count;
            set
            {
                wordsCount = value;
                OnPropertyChanged("WordsCount");
            }
        }

        #endregion
        #endregion

        #region Commands

        #region DeleteCommand

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
            {
                App.DeckVM.Decks.Remove(this);
            }));
        }

        #endregion

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
