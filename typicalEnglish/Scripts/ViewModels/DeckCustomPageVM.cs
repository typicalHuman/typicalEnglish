﻿using System.Collections.ObjectModel;
using typicalEnglish.Scripts.Models;
using ImageSource = typicalEnglish.Scripts.Models.ImageSource;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Deck customization view model.
    /// </summary>
    public class DeckCustomPageVM: BaseViewModel
    {
        #region Constructor
        /// <summary>
        /// Initialize deck color and title image.
        /// </summary>
        /// <param name="deck">Deck to customize.</param>
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

        #region Constants

        private const string IMAGE_FILTER = "Image files (*.png,*.jpg,*jpeg)|*.png;*.jpg;*jpeg";



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

        /// <summary>
        /// Images from application resources.
        /// </summary>
        public ObservableCollection<ImageSource> ImageSources { get; set; } = new ObservableCollection<ImageSource>()
        {
            "pack://application:,,,/Resources/Images/typography.png",
            "pack://application:,,,/Resources/Images/bolt.png",
            "pack://application:,,,/Resources/Images/star.png",
            "pack://application:,,,/Resources/Images/booklet.png",
            "pack://application:,,,/Resources/Images/bookshelf.png",
            "pack://application:,,,/Resources/Images/briefcase.png",
            "pack://application:,,,/Resources/Images/caution.png",
            "pack://application:,,,/Resources/Images/chat.png",
            "pack://application:,,,/Resources/Images/check.png",
            "pack://application:,,,/Resources/Images/clapboard.png",
            "pack://application:,,,/Resources/Images/compose.png",
            "pack://application:,,,/Resources/Images/genius.png",
            "pack://application:,,,/Resources/Images/target.png",
            "pack://application:,,,/Resources/Images/airport.png",
            "pack://application:,,,/Resources/Images/beach.png",
            "pack://application:,,,/Resources/Images/bookpencil.png",
            "pack://application:,,,/Resources/Images/geography.png",
            "pack://application:,,,/Resources/Images/glossary.png",
            "pack://application:,,,/Resources/Images/knowledgetransfer.png",
            "pack://application:,,,/Resources/Images/about.png",
            "pack://application:,,,/Resources/Images/bookmark.png",
            "pack://application:,,,/Resources/Images/female.png",
            "pack://application:,,,/Resources/Images/male.png",
            "pack://application:,,,/Resources/Images/music.png",
            "pack://application:,,,/Resources/Images/news.png",
            "pack://application:,,,/Resources/Images/learning.png"
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
        /// <summary>
        /// Open file on PC.
        /// </summary>
        public RelayCommand OpenImageCommand
        {
            get => openImageCommand ?? (openImageCommand = new RelayCommand(obj =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = IMAGE_FILTER
                };
                bool? result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    SetDeckSource(filename);
                }
            }));
        }

        #endregion

        #region BackCommand
        private RelayCommand backCommand;
        /// <summary>
        /// Back to decks choosing page.
        /// </summary>
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate(Paths.DECKS_PAGE);
            }));
        }
        #endregion

        #endregion
    }
}
