using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DeckCustomPageVM: INotifyPropertyChanged
    {
        #region Constructor

        public DeckCustomPageVM(Deck deck)
        {
            this.Deck = deck;
            SetSelectedValue();
        }

        #endregion

        #region Methods

        private void SetSelectedValue()
        {
            foreach(ImageSource source in ImageSources)
            {
                if (Deck.ImageSource == source)
                    source.IsSelected = true;
                else
                    source.IsSelected = false;
            }
        }

        private void SetDeckSource(string source)
        {
            Deck.ImageSource = source;
            SetSelectedValue();
        }
        #endregion

        #region Properties

        #region Deck
        private Deck deck;
        public Deck Deck
        {
            get => deck;
            set
            {
                deck = value;
                OnPropertyChanged("Deck");
            }
        }
        #endregion

        public ObservableCollection<ImageSource> ImageSources { get; set; } = new ObservableCollection<ImageSource>()
        {
            "pack://application:,,,/Resources/Images/typography.png",
            "pack://application:,,,/Resources/Images/bolt.png",
            "pack://application:,,,/Resources/Images/star.png"
        };

        #endregion

        #region Commands

        #region SetImageCommand
        private RelayCommand setImageCommand;
        public RelayCommand SetImageCommand
        {
            get => setImageCommand ?? (setImageCommand = new RelayCommand(obj =>
            {
                SetDeckSource(obj.ToString());
            }));
        }
        #endregion

        #region OpenImageCommand

        private RelayCommand openImageCommand;
        public RelayCommand OpenImageCommand
        {
            get => openImageCommand ?? (openImageCommand = new RelayCommand(obj =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Image files (*.png,*.jpg,*jpeg)|*.png;*.jpg;*jpeg" ;
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    SetDeckSource(filename);
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
