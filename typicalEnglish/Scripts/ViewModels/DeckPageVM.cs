using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DeckPageVM: INotifyPropertyChanged
    {

        public DeckPageVM(ObservableCollection<Word> words)
        {
            Words = words;
        }

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


        #region ShowInfoCommand
        private RelayCommand showInfoCommand;
        public RelayCommand ShowInfoCommand
        {
            get => showInfoCommand ?? (showInfoCommand = new RelayCommand(obj =>
            {
                MoreVisibility = MoreVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            }));
        }
        #endregion

        #region SpeakCommand

        private RelayCommand speakCommand;
        public RelayCommand SpeakCommand
        {
            get => speakCommand ?? (speakCommand = new RelayCommand(obj =>
            {
                Word word = obj as Word;
                if(word != null)
                {
                    if(word.PronunciationSource == "Auto")
                    {
                        App.DecksVM.Synthesizer.SpeakAsync(word.Spelling);
                    }
                }
            }));
        }

        #endregion


        #endregion

        #region Properties
        public ObservableCollection<Word> Words { get; set; }

        #region MoreVisibility

        private Visibility moreVisibility = Visibility.Collapsed;
        public Visibility MoreVisibility
        {
            get => moreVisibility;
            set
            {
                moreVisibility = value;
                OnPropertyChanged("MoreVisibility");
            }
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
