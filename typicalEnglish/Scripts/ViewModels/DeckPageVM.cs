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
    public class DeckPageVM: INotifyPropertyChanged
    {
        #region Properties

        public ObservableCollection<Deck> Decks { get; set; } = new ObservableCollection<Deck>()
        {
            new Deck(){Name = "CEEEEEEC"},
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
