using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    public class Deck: INotifyPropertyChanged
    {
        #region Properties
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();

        #region ImageSource

        private string imageSource = @"pack://application:,,,/Resources/Images/typography.png";
        public string ImageSource
        {
            get => imageSource;
            set
            {
                imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        #endregion

        #region Name

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        #endregion

        #region WordsCount

        private int wordsCount;
        [JsonIgnore]
        public int WordsCount
        {
            get => Words.Count;
            set
            {
                wordsCount = value;
                OnPropertyChanged("WordsCount");
            }
        }

        #endregion

        #region Background

        private Brush background;
        public Brush Background
        {
            get => background;
            set
            {
                background = value;
                OnPropertyChanged("Background");
            }
        }

        #endregion

        #region BorderBrush

        private Brush borderBrush = (Brush)new BrushConverter().ConvertFrom("#03a9f4");
        public Brush BorderBrush
        {
            get => borderBrush;
            set
            {
                borderBrush = value;
                OnPropertyChanged("BorderBrush");
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
