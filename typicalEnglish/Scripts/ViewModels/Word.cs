using ICSharpCode.AvalonEdit.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using typicalEnglish.Scripts.Models;
namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// View model for word abstraction.
    /// </summary>
    public class Word: TestValue, INotifyPropertyChanged
    {
        #region Methods

        /// <summary>
        /// Play word spelling by its source.
        /// </summary>
        public void PlaySound()
        {
            WordSoundPlayer.PlayWordSpelling(this);
        }

        #endregion

        #region Properties

        #region Colorizing
        private DocumentColorizingTransformer colorizing;
        /// <summary>
        /// Colorizing property for <see cref="MvvmTextEditor"/>.
        /// </summary>
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
        /// <summary>
        /// Source of file which will play in <see cref="PlaySound"/> method.
        /// If value equals Auto, then synthesizer will play windows standard voice.
        /// </summary>
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
        /// <summary>
        /// Visibility for more word editing. 
        /// </summary>
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
        /// <summary>
        /// Is editing word now. 
        /// It needs for more beauty in DeckPage view.
        /// </summary>
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
        /// <summary>
        /// Show more info. Refer to <see cref="MoreVisibility"/>.
        /// </summary>
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
        /// <summary>
        /// Play word's spelling by its source.
        /// </summary>
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
        /// <summary>
        /// Edit word content.
        /// </summary>
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
        /// <summary>
        /// Open sound file on PC.
        /// </summary>
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
        /// <summary>
        /// A piece of shit (needs for property changed event)
        /// </summary>
        [JsonIgnore]
        public RelayCommand InitializeValueCommand
        {
            get => initializeValueCommand ?? (initializeValueCommand = new RelayCommand(obj =>
            {
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
