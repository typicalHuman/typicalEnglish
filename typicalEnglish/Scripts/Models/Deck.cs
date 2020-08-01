﻿using Newtonsoft.Json;
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
        #region Properties
        /// <summary>
        /// Words that belong to this deck.
        /// </summary>
        public ObservableCollection<Word> Words { get; set; } = new ObservableCollection<Word>();

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

        private Color background = Colors.White;
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

        private Color foreground = Colors.Black;
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
        private Color borderColor = (Color)new ColorConverter().ConvertFrom("#03a9f4");
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
        private Color underlineColor = (Color)new ColorConverter().ConvertFrom("#03a9f4");
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
