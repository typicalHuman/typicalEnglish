using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace typicalEnglish.Scripts.Models
{
    public class Word: INotifyPropertyChanged
    {
        #region Properties

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
        public string Transcirption
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

        private string pronunciationSource;
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
