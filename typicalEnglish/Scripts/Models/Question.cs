using System.ComponentModel;
using System.Runtime.CompilerServices;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    public class Question: INotifyPropertyChanged
    {
        #region Methods

        private void SetCorrectAnswer()
        {
            if (Word.Translations.Count > 0)
                CorrectAnswer = Word.Translations[0];
            else
                CorrectAnswer = "isn't specified";
        }

        #endregion

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
                SetCorrectAnswer();
                OnPropertyChanged("Word");
            }
        }
        #endregion

        #region CorrectAnswer
        private string correctAnswer;
        public string CorrectAnswer
        {
            get => correctAnswer;
            set
            {
                correctAnswer = value;
                OnPropertyChanged("CorrectAnswer");
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
