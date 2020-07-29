using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
        }

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

        #endregion

        #region Properties

        public ObservableCollection<Question> Questions { get; set; }

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

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
