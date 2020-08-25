using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for checking answers on exam event.
    /// </summary>
    public class Question: BaseViewModel
    {
        #region Constants
        public const string EMPTY_TRANSLATIONS = "isn't specified";
        #endregion

        #region Methods

        private void SetCorrectAnswer()
        {
            if (Word.Translations.Count > 0)
                CorrectAnswer = Word.Translations[0];
            else
                CorrectAnswer = EMPTY_TRANSLATIONS;
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
        /// <summary>
        /// User's answer.
        /// </summary>
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
        /// <summary>
        /// Word to test.
        /// </summary>
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
        /// <summary>
        /// First translation to show, when user answers wrong.
        /// </summary>
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
    }
}
