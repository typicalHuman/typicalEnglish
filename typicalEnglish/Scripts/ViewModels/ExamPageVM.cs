using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class ExamPageVM: INotifyPropertyChanged
    {
        #region Extensions

        private static Random rng = new Random();

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initialize exam
        /// </summary>
        /// <param name="selectedWords">words that will be in the test</param>
        public ExamPageVM(ObservableCollection<Word> selectedWords)
        {
            foreach (Word w in selectedWords)
                Questions.Add(w);
            Shuffle(Questions);
            CurrentQuestion = Questions[0];
        }

        #endregion

        #region Properties
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

        #region CurrentQuestion
        private Question currentQuestion;
        public Question CurrentQuestion
        {
            get => currentQuestion;
            set
            {
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
            }
        }
        #endregion

        #region IsChecked

        private bool isChecked;
        public bool IsChecked
        {
            get => isChecked;
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        #endregion

        #region QuestionNumber

        private int questionNumber = 1;
        public int QuestionNumber
        {
            get => questionNumber;
            set
            {
                questionNumber = value;
                OnPropertyChanged("QuestionNumber");
            }
        }
        #endregion

        #endregion

        #region Constants

        private readonly Stream CORRECT_SOUND_STREAM = new MemoryStream(Properties.Resources.correct);
        private readonly Stream WRONG_SOUND_STREAM = new MemoryStream(Properties.Resources.wrong);

        #endregion

        #region Methods

        #region AnswerActions

        private void CorrectAnswerAction()
        {
            WordSoundPlayer.PlayAudio(CORRECT_SOUND_STREAM);
        }

        private void WrongAnswerAction()
        {
            WordSoundPlayer.PlayAudio(WRONG_SOUND_STREAM);
        }

        #endregion

        private void CorrectnessCheck()
        {
            foreach (string translation in CurrentQuestion.Word.Translations)
            {
                if (translation.ToLower() == CurrentQuestion.Answer.ToLower())
                {
                    CurrentQuestion.IsCorrect = true;
                    break;
                }
            }
        }

        #endregion

        #region Commands

        #region CloseTestCommand

        private RelayCommand closeTestCommand;
        public RelayCommand CloseTestCommand
        {
            get => closeTestCommand ?? (closeTestCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate("Scripts/Views/TestPage.xaml");
            }));
        }

        #endregion

        #region CheckAnswerCommand

        private RelayCommand checkAnswerCommand;
        public RelayCommand CheckAnswerCommand
        {
            get => checkAnswerCommand ?? (checkAnswerCommand = new RelayCommand(obj =>
            {
                CorrectnessCheck();
                if (CurrentQuestion.IsCorrect)
                    CorrectAnswerAction();
                else
                    WrongAnswerAction();
                IsChecked = true;
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
