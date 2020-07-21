using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class TestPageVM : INotifyPropertyChanged
    {

        #region Commands

        #region ChangeVisibilityCommand
        private RelayCommand changeVisibilityCommand;
        public RelayCommand ChangeVisibilityCommand
        {
            get => changeVisibilityCommand ?? (changeVisibilityCommand = new RelayCommand(obj =>
            {
                MoreVisibility = MoreVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }));
        }
        #endregion

        #region SelectAllCommand
        private RelayCommand selectAllCommand;
        public RelayCommand SelectAllCommand
        {
            get => selectAllCommand ?? (selectAllCommand = new RelayCommand(obj =>
            {
                foreach (Deck deck in App.DecksVM.Decks)
                    deck.IsSelected = true;
            }));
        }
        #endregion

        #region SelectFirstCommand
        private RelayCommand selectFirstCommand;
        public RelayCommand SelectFirstCommand
        {
            get => selectFirstCommand ?? (selectFirstCommand = new RelayCommand(obj =>
            {
                int wordsCount = 0; 
                if(int.TryParse(obj.ToString(), out wordsCount))
                {
                    wordsCount = int.Parse(obj.ToString());
                    for (int i = 0; i < App.DecksVM.Decks.Count; i++)
                    {
                        if (i < wordsCount)
                            App.DecksVM.Decks[i].IsSelected = true;
                        else
                            App.DecksVM.Decks[i].IsSelected = false;
                    }

                }
            }));
        }
        #endregion

        #endregion

        #region Properties

        public ObservableCollection<Deck> Decks { get; set; } = new ObservableCollection<Deck>();

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

        #region IsDeckPage

        private bool isDeckPage = true;
        public bool IsDeckPage
        {
            get => isDeckPage;
            set
            {
                isDeckPage = value;
                OnPropertyChanged("IsDeckPage");
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
