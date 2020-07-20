using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using System.Windows;
using typicalEnglish.Scripts.Models;
using typicalEnglish.Scripts.Views;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DecksPageVM: INotifyPropertyChanged
    {
        #region Constructor
        public DecksPageVM()
        {
            Decks = JSONData.GetSavedDecks();
            synthesizer = new SpeechSynthesizer();
            synthesizer.SelectVoice("Microsoft Zira Desktop");
        }
        #endregion

        #region Properties

        public ObservableCollection<Deck> Decks { get; set; } 

        #region Synthersizer

        private SpeechSynthesizer synthesizer;
        public SpeechSynthesizer Synthesizer
        {
            get => synthesizer;
            set
            {
                synthesizer = value;
                OnPropertyChanged("Synthesizer");
            }
        }

        #endregion

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
                var res = Xceed.Wpf.Toolkit.MessageBox.Show(
                          "Are you sure?",
                          "Confirm dialog",
                          MessageBoxButton.YesNo,
                          (Style)Application.Current.FindResource("ConfirmBoxStyle")
                      );
                if(res.ToString() == "Yes")
                   Decks.Remove(obj as Deck);
            }));
        }

        #endregion

        #region OpenDeckCommand
        private RelayCommand openDeckCommand;
        public RelayCommand OpenDeckCommand
        {
            get => openDeckCommand ?? (openDeckCommand = new RelayCommand(obj =>
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

        #region OpenDeckCustomizationCommand
        private RelayCommand openDeckCustomizationCommand;
        public RelayCommand OpenDeckCustomizationCommand
        {
            get => openDeckCustomizationCommand ?? (openDeckCustomizationCommand = new RelayCommand(obj =>
            {
                Deck deck = obj as Deck;
                if (deck != null)
                {
                    App.DeckCustomVM = new DeckCustomPageVM(deck);
                    App.MainVM.Navigate("Scripts/Views/DeckCustomizationPage.xaml");
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
