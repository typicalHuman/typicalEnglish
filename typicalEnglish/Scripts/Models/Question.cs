using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    public class Question: INotifyPropertyChanged
    {
        #region Properties

        #region IsCorrect

        private bool isCorrect;
        public bool IsCorrect
        {
            get => isCorrect;
            set
            {
                isCorrect = value;
                OnPropertyChanged("IsCorrect");
            }
        }
        #endregion

        #region Answer

        private string answer = "";
        public string Answer
        {
            get => answer;
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }
        #endregion

        #region Word

        private Word word;
        public Word Word
        {
            get => word;
            set
            {
                word = value;
                OnPropertyChanged("Word");
            }
        }
        #endregion

        #endregion

        #region Operators

        public static implicit operator Word(Question quest)
        {
            return quest.Word;
        }

        public static implicit operator Question(Word word)
        {
            return new Question() { Word = word };
        }

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
