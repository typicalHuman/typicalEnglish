using ICSharpCode.AvalonEdit.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using typicalEnglish.Scripts.Models;
namespace typicalEnglish.Scripts.ViewModels
{
    public class Word: TestValue, INotifyPropertyChanged
    {
        #region Methods

        public void PlaySound()
        {
            WordSoundPlayer.PlayWordSpelling(this);
        }

        #endregion

        #region Properties

        #region Colorizing
        private DocumentColorizingTransformer colorizing;
        [JsonIgnore]
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
                transcription = value?.Replace("[", "").Replace("]", "");
                OnPropertyChanged("Transcription");
            }
        }
        #endregion

        public ObservableCollection<MutableString> Translations { get; set; } = new ObservableCollection<MutableString>();

        public ObservableCollection<MutableString> Examples { get; set; } = new ObservableCollection<MutableString>();

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
        [JsonIgnore]
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
        [JsonIgnore]
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
        [JsonIgnore]
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
        [JsonIgnore]
        public RelayCommand EditCommand
        {
            get => editCommand ?? (editCommand = new RelayCommand(obj =>
            {
                IsEditing = !IsEditing;
                JSONData.Save(App.DecksVM.Decks);
            }));
        }
        #endregion

        #region AddTranslationCommand
        private RelayCommand addTranslationCommand;
        [JsonIgnore]
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
        [JsonIgnore]
        public RelayCommand DeleteTranslationCommand
        {
            get => deleteTranslationCommand ?? (deleteTranslationCommand = new RelayCommand(obj =>
            {
                Translations.Remove(obj as MutableString);
            }));
        }
        #endregion

        #region AddExampleCommand
        private RelayCommand addExampleCommand;
        [JsonIgnore]
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
        [JsonIgnore]
        public RelayCommand DeleteExampleCommand
        {
            get => deleteExampleCommand ?? (deleteExampleCommand = new RelayCommand(obj =>
            {
                Examples.Remove(obj as MutableString);
            }));
        }
        #endregion

        #region ChangeSoundFileCommand

        private RelayCommand changeSoundFileCommand;
        [JsonIgnore]
        public RelayCommand ChangeSoundFileCommand
        {
            get => changeSoundFileCommand ?? (changeSoundFileCommand = new RelayCommand(obj =>
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Audio files (*.mp3,*.wav)|*.mp3;*.wav";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    PronunciationSource = filename;
                }
            }));
        }

        #endregion

        #region InitializeValueCommand

        private RelayCommand initializeValueCommand;
        [JsonIgnore]
        public RelayCommand InitializeValueCommand
        {
            get => initializeValueCommand ?? (initializeValueCommand = new RelayCommand(obj =>
            {
                //a piece of shit (needs for property changed event)
                for (int i = 0; i < Examples.Count; i++)
                {
                    Examples[i] = Examples[i] + " ";
                    Examples[i] = Examples[i].Value.Remove(Examples[i].Value.Length - 1);
                }
            }));
        }

        #endregion

        #endregion
    }
}
