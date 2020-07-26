using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public ExamPageVM(ObservableCollection<Word> selectedWords)
        {
            foreach (Word w in selectedWords)
                Questions.Add(w);
            Shuffle(Questions);
            if (Questions.Count > 0)
                CurrentQuestion = Questions[0];
        }

        #region Properties

        private ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

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
                foreach(string translation in CurrentQuestion.Word.Translations)
                    if(translation.ToLower() == CurrentQuestion.Answer.ToLower())
                    {
                        CurrentQuestion.IsCorrect = true;
                        break;
                    }
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
