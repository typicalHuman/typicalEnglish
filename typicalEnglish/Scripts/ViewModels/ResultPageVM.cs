using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class ResultPageVM: INotifyPropertyChanged
    {
        #region Constructor

        public ResultPageVM(ObservableCollection<Question> questions)
        {
            Questions = questions;
            CorrectAnswersCount = GetCorrectCount();
            SetGifSource();
        }

        #endregion

        #region Constants

        private const int FIFTY_PERCENTAGE = 50;

        private const string SAD_GIF_PATH = "pack://application:,,,/Resources/Gifs/sad.gif";
        private const string FUN_GIF_PATH = "pack://application:,,,/Resources/Gifs/fun.gif";

        private const string SELECT_DECKS_PAGE_PATH = "Scripts/Views/TestPage.xaml";

        #endregion

        #region Methods

        private int GetCorrectCount()
        {
            int counter = 0;
            foreach (Question q in Questions)
                if (q.IsCorrect)
                    counter++;
            return counter;
        }

        private bool IsSadGif()
        {
            int percentage = Percentage(CorrectAnswersCount, Questions.Count);
            return percentage < FIFTY_PERCENTAGE;
        }

        private void SetGifSource()
        {
            bool isSadGif = IsSadGif();
            if (isSadGif)
                GifSource = SAD_GIF_PATH;
            else
                GifSource = FUN_GIF_PATH;
        }

        private static int Percentage(double number, double amount)
        {
            return (int)(number / amount * 100.0);
        }

        #endregion

        #region Properties

        public ObservableCollection<Question> Questions { get; set; }

        #region GifSource
        private string gifSource;
        public string GifSource
        {
            get => gifSource;
            set
            {
                gifSource = value;
                OnPropertyChanged("GifSource");
            }
        }
        #endregion

        #region CorrectAnswersCount

        private int correctAnswersCount;
        public int CorrectAnswersCount
        {
            get => correctAnswersCount;
            set
            {
                correctAnswersCount = value;
                OnPropertyChanged("CorrectAnswersCount");
            }
        }
        #endregion

        #endregion

        #region Commands

        #region FinishExamCommand


        private RelayCommand finishExamCommand;
        public RelayCommand FinishExamCommand
        {
            get => finishExamCommand ?? (finishExamCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate(SELECT_DECKS_PAGE_PATH);
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
