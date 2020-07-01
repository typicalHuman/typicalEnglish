using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DecksPageVM: INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<Deck> Decks { get; set; } = new ObservableCollection<Deck>()
        {
            new Deck(){Name = "CEEEEEEC", Words = new ObservableCollection<Word>()
            {
                new Word(){Spelling = "Fuck", Transcription="fʌk"}
            } },
            new Deck(){Name = "FUUUUUU"},
            new Deck(){Name = "FUUUUUU"},
            new Deck(){Name = "CEEEEEEC"},
            new Deck(){Name = "FUUUUUU"},
            new Deck(){Name = "FUUUUUU"},
            new Deck(){Name = "CEEEEEEC"},
            new Deck(){Name = "FUUUUUU"},
            new Deck(){Name = "FUUUUUU"},
            new Deck(){Name = "FUUUUUU"}
        };

        #endregion

        #region Commands

        #region AddCommand
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get => addCommand ?? (addCommand = new RelayCommand(obj =>
            {
                Decks.Insert(0, new Deck());
            }));
        }
        #endregion


        #region DeleteCommand

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get => deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
            {
                Decks.Remove(obj as Deck);
            }));
        }

        #endregion

        #region OpenCommand
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get => openCommand ?? (openCommand = new RelayCommand(obj =>
            {
                Deck deck = obj as Deck;
                if (deck != null)
                {
                    App.DeckVM = new DeckPageVM(deck.Words);
                    App.MainVM.Navigate("Scripts/Views/DeckPage.xaml");
                }
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
