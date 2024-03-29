﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Media;
using typicalEnglish.Scripts.Models;
using typicalEnglish.Scripts.ViewModels.Converters;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// ViewModel for exam.
    /// </summary>
    public class ExamPageVM: BaseViewModel
    {
        #region Extensions

        private static Random rng = new Random();
        /// <summary>
        /// Shuffle elements of collection.
        /// </summary>
        /// <typeparam name="T">Question.</typeparam>
        /// <param name="list">Collection to shuffle.</param>
        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 0)
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
        /// Initialize exam.
        /// </summary>
        /// <param name="selectedWords">Words which will be in the test.</param>
        public ExamPageVM(ObservableCollection<Word> selectedWords)
        {
            if (selectedWords.Count > 0)
            {
                foreach (Word w in selectedWords)
                    Questions.Add(w);
                Shuffle(Questions);
                CurrentQuestion = Questions[0];
                IsLastWord = Questions.Count == 1;
                if (!IsEnglish)
                    SetSpellings();
            }
        }

        #endregion

        #region Properties
        public ObservableCollection<Question> Questions { get; set; } = new ObservableCollection<Question>();

        #region CurrentQuestion
        private Question currentQuestion;
        /// <summary>
        /// Question which see user.
        /// </summary>
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
        /// <summary>
        /// Is answer panel visible.
        /// </summary>
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
        /// <summary>
        /// Current question number.
        /// </summary>
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

        #region IsLastWord

        private bool isLastWord;
        /// <summary>
        /// Is last word and end of the test.
        /// </summary>
        public bool IsLastWord
        {
            get => isLastWord;
            set
            {
                isLastWord = value;
                OnPropertyChanged("IsLastWord");
            }
        }

        #endregion

        #region IsEnglish

        public bool IsEnglish { get; set; } = App.SelectWordVM.IsEnglish;

        #endregion

        #region AllTranslations

        /// <summary>
        /// All translations of all words.
        /// </summary>
        private List<string> spellings { get; set; } = new List<string>();

        #endregion

        #endregion

        #region Constants

        private readonly Stream CORRECT_SOUND_STREAM = Properties.Resources.correct;
        private readonly Stream WRONG_SOUND_STREAM = Properties.Resources.wrong;

        private const string SELECT_DECKS_SOURCE = "SelectDecksPage.xaml";

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
                string trans = StringEditor.RemoveExcessSymbols(translation);
                string answer = StringEditor.RemoveExcessSymbols(CurrentQuestion.Answer);
                if (trans == answer)
                {
                    CurrentQuestion.IsCorrect = true;
                    break;
                }
            }
        }

        private void CorrectnessTranslationCheck()
        {
            string answer = StringEditor.RemoveExcessSymbols(CurrentQuestion.Answer);
            string spelling = StringEditor.RemoveExcessSymbols(currentQuestion.Word.Spelling);
            if (answer == spelling)
            {
                CurrentQuestion.IsCorrect = true;
            }
            else
            {
                string firstTranslation = WordDisplayConverter.GetTranslation(CurrentQuestion.Word);
                foreach(Question q in Questions)
                {
                    spelling = StringEditor.RemoveExcessSymbols(q.Word.Spelling);
                    if(answer == spelling)
                    {
                        foreach(string tr in CurrentQuestion.Word.Translations)
                        {
                            if (IsInCollection(q.Word.Translations, tr))
                            {
                                CurrentQuestion.IsCorrect = true;
                                break;
                            }
                        }
                    }
                   
                }
            }
        }

        /// <summary>
        /// Check is all translations contains first translation.
        /// </summary>
        /// <param name="translations"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        private bool IsInCollection(ObservableCollection<MutableString> translations, string first)
        {
            foreach (string tr in translations)
                if (first == tr)
                    return true;
            return false;
        }

        /// <summary>
        /// Return options to deck page.
        /// </summary>
        private void UpdateTestPage()
        {
            App.TestPageVM.IsDeckPage = true;
            App.TestPageVM.Source = SELECT_DECKS_SOURCE;
        }
        private void SelectNextWord()
        {
            if (QuestionNumber < Questions.Count)
            {
                IsChecked = false;
                CurrentQuestion = Questions[QuestionNumber];
                QuestionNumber++;
            }
            else
            {
                UpdateTestPage();
                App.ResultPageVM = new ResultPageVM(Questions);
                App.MainVM.Navigate(Paths.RESULT_PAGE);
            }
            if(QuestionNumber == Questions.Count)
                IsLastWord = true;
        }
        private void AnswerCheckedAction()
        {
            if (CurrentQuestion.IsCorrect)
                CorrectAnswerAction();
            else
                WrongAnswerAction();
            IsChecked = true;
        }
        /// <summary>
        /// Initializing all words spelling to check words with the same meanings.
        /// </summary>
        private void SetSpellings()
        {
            foreach (Question q in Questions)
                spellings.Add(q.Word.Spelling);
        }

        #endregion

        #region Commands

        #region CloseTestCommand

        private RelayCommand closeTestCommand;
        /// <summary>
        /// Return to test page.
        /// </summary>
        public RelayCommand CloseTestCommand
        {
            get => closeTestCommand ?? (closeTestCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate(Paths.TEST_PAGE);
            }));
        }

        #endregion

        #region CheckAnswerCommand

        private RelayCommand checkAnswerCommand;
        public RelayCommand CheckAnswerCommand
        {
            get => checkAnswerCommand ?? (checkAnswerCommand = new RelayCommand(obj =>
            {
                if (CurrentQuestion.Answer.Length > 0)
                {
                    if (!IsChecked)
                    {
                        if (IsEnglish)
                            CorrectnessCheck();
                        else
                            CorrectnessTranslationCheck();
                        AnswerCheckedAction();
                    }
                    else
                    {
                        SelectNextWord();
                    }
                }
            }));
        }

        #endregion

        #region NextWordCommand

        private RelayCommand nextWordCommand;
        /// <summary>
        /// Change current question.
        /// </summary>
        public RelayCommand NextWordCommand
        {
            get => nextWordCommand ?? (nextWordCommand = new RelayCommand(obj =>
            {
                SelectNextWord();
            }));
        }

        #endregion

        #endregion
    }
}
