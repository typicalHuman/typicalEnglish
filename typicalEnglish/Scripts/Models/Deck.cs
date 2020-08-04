using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Model for deck abstraction.
    /// </summary>
    public class Deck: TestValue, INotifyPropertyChanged
    {
        #region Constructor
        public Deck()
        {
            Foreground = BLUE_COLOR;
            BorderColor = BLUE_COLOR;
            UnderlineColor = BLUE_COLOR;
            Background = WHITE_COLOR;
        }
                #endregion

        #region Properties
        /// <summary>
        /// Words that belong to this deck.
        /// </summary>
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();

        private readonly Color BLUE_COLOR = (Color)new ColorConverter().ConvertFrom("#03a9f4");
        private readonly Color WHITE_COLOR = (Color)new ColorConverter().ConvertFrom("#f2f2f3");

        #region ImageSource

        private string imageSource = @"pack://application:,,,/Resources/Images/typography.png";
        /// <summary>
        /// Title image source.
        /// </summary>
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

        private Color background;
        public Color Background
        {
            get => background;
            set
            {
                background = value;
                OnPropertyChanged("Background");
            }
        }
        #endregion

        #region Foreground

        private Color foreground;
        public Color Foreground
        {
            get => foreground;
            set
            {
                foreground = value;
                OnPropertyChanged("Foreground");
            }
        }

        #endregion

        #region BorderColor
        private Color borderColor;
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                OnPropertyChanged("BorderColor");
            }
        }

        #endregion

        #region UnderlineColor
        private Color underlineColor;
        /// <summary>
        /// Underline color of textbox.
        /// </summary>
        public Color UnderlineColor
        {
            get => underlineColor;
            set
            {
                underlineColor = value;
                OnPropertyChanged("UnderlineColor");
            }
        }

        #endregion

        #endregion
    }
}
