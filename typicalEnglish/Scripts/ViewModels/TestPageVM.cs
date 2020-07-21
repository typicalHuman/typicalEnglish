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

        #region CheckedDeckCommand
        private RelayCommand checkedDeckCommand;
        public RelayCommand CheckedDeckCommand
        {
            get => checkedDeckCommand ?? (checkedDeckCommand = new RelayCommand(obj =>
            {
                SelectedDecks.Add(obj as Deck);
            }));
        }
        #endregion

        #region UncheckedDeckCommand
        private RelayCommand uncheckedDeckCommand;
        public RelayCommand UncheckedDeckCommand
        {
            get => uncheckedDeckCommand ?? (uncheckedDeckCommand = new RelayCommand(obj =>
            {
                SelectedDecks.Remove(obj as Deck);
            }));
        }
        #endregion

        #endregion

        #region Properties

        public ObservableCollection<Deck> SelectedDecks { get; set; } = new ObservableCollection<Deck>();

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
