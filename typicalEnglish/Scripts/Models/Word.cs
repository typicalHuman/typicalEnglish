using ICSharpCode.AvalonEdit.Rendering;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    public class Word: INotifyPropertyChanged
    {

        #region Methods

        public void PlaySound()
        {
            WordSoundPlayer.PlaySound(this);
        }

        #endregion

        #region Properties

        #region Colorizing

        private DocumentColorizingTransformer colorizing;
        public DocumentColorizingTransformer Colorizing
        {
            get => colorizing = new WordColorizing(Spelling);
            set
            {
                colorizing = value;
                OnPropertyChanged("Colorizing");
            }
        }
        #endregion

        #region Spelling

        private string spelling;
        public string Spelling
        {
            get => spelling;
            set
            {
                spelling = value;
                OnPropertyChanged("Spelling");
            }
        }
        #endregion

        #region Transcription

        private string transcription;
        public string Transcription
        {
            get => transcription;
            set
            {
                transcription = value;
                OnPropertyChanged("Transcription");
            }
        }
        #endregion

        public ObservableCollection<string> Translations { get; set; }

        public ObservableCollection<string> Examples { get; set; }

        #region PronunciationSource

        private string pronunciationSource = "Auto";
        public string PronunciationSource
        {
            get => pronunciationSource;
            set
            {
                pronunciationSource = value;
                OnPropertyChanged("PronunciatonSource");
            }
        }

        #endregion

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

        #region IsEditing

        private bool isEditing = false;
        public bool IsEditing
        {
            get => isEditing;
            set
            {
                isEditing = value;
                OnPropertyChanged("IsEditing");
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

        #region Commands

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
                PlaySound();
            }));
        }

        #endregion

        #region EditCommand
        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get => editCommand ?? (editCommand = new RelayCommand(obj =>
            {
                IsEditing = !IsEditing;
            }));
        }
        #endregion

        #region AddTranslationCommand
        private RelayCommand addTranslationCommand;
        public RelayCommand AddTranslationCommand
        {
            get => addTranslationCommand ?? (addTranslationCommand = new RelayCommand(obj =>
            {
                Translations.Add("");
            }));
        }
        #endregion

        #region DeleteTranslationCommand
        private RelayCommand deleteTranslationCommand;
        public RelayCommand DeleteTranslationCommand
        {
            get => deleteTranslationCommand ?? (deleteTranslationCommand = new RelayCommand(obj =>
            {
                Translations.Remove(obj.ToString());
            }));
        }
        #endregion

        #region AddExampleCommand
        private RelayCommand addExampleCommand;
        public RelayCommand AddExampleCommand
        {
            get => addExampleCommand ?? (addExampleCommand = new RelayCommand(obj =>
            {
                Examples.Add(spelling);
            }));
        }
        #endregion

        #region DeleteExampleCommand
        private RelayCommand deleteExampleCommand;
        public RelayCommand DeleteExampleCommand
        {
            get => deleteExampleCommand ?? (deleteExampleCommand = new RelayCommand(obj =>
            {
                Examples.Remove(obj.ToString());
            }));
        }
        #endregion

        #endregion
    }
}
