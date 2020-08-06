using System.Collections.ObjectModel;
using System.Windows;
using typicalEnglish.Scripts.Models;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// View model for test tab.
    /// </summary>
    public class TestPageVM : BaseViewModel
    {
        #region Constructor
        /// <summary>
        /// Update decks selections.
        /// </summary>
        public TestPageVM()
        {
            SetDecksSelections();
        }
        #endregion


        #region SetDecksSelections

        private void SetDecksSelections()
        {
            DeckHelper.SetDecksSelections(Decks);
        }

        #endregion

        #region Constants

        private readonly Action EMPTY_ACT = () => { };

        private const string SELECT_WORDS_SOURCE = "SelectWordsPage.xaml";
        private const string SELECT_DECKS_SOURCE = "SelectDecksPage.xaml";

        #endregion

        #region Methods

        private ObservableCollection<Word> GetWordsFromDecks()
        {
            List<Word> words = new List<Word>();
            foreach (Deck deck in App.DecksVM.Decks)
                if (deck.IsSelected)
                    words.AddRange(deck.Words);
            return new ObservableCollection<Word>(words);
        }

        #region Navigation

        public void Navigate(string url)
        {
            Messenger.Default.Send(new NavigateArgs(url));
        }

        private void OpenSelectWordsPage()
        {
            App.SelectWordVM = new SelectWordsPageVM(GetWordsFromDecks());
            IsDeckPage = false;
            Navigate(Paths.SELECT_WORDS_PAGE);
        }

        private void StartTest()
        {
            App.ExamPageVM = new ExamPageVM(App.SelectWordVM.GetSelectedWords());
            App.MainVM.Navigate(Paths.EXAM_PAGE);
        }


        #endregion

        #region SetAll

        private void SetAllDecks()
        {
            SetAllValues(App.DecksVM.Decks.Cast<TestValue>().ToList(), SetDecksSelections);
        }

        private void SetAllWords()
        {
            SetAllValues(App.SelectWordVM.Words.Cast<TestValue>().ToList(), EMPTY_ACT);
        }

        private void SetAllValues(List<TestValue> values, Action setSelections)
        {
            if (IsAllSelected(values))
            {
                foreach (TestValue v in values)
                    v.IsSelected = false;
            }
            else
            {
                foreach (TestValue v in values)
                    v.IsSelected = true;
            }
            setSelections();
        }

        private bool IsAllSelected(List<TestValue> values)
        {
            foreach (TestValue value in values)
                if (!value.IsSelected)
                    return false;
            return true;
        }

        #endregion

        #region SetFirst

        private void SetFirstDecks(object obj)
        {
            SetFirst(obj, App.DecksVM.Decks.Cast<TestValue>().ToList(), SetDecksSelections);
        }

        private void SetFirstWords(object obj)
        {
            SetFirst(obj, App.SelectWordVM.Words.Cast<TestValue>().ToList(), EMPTY_ACT);
        }

        private void SetFirst(object obj, List<TestValue> values, Action SetSelections)
        {
            if (int.TryParse(obj.ToString(), out int valuesCount))
            {
                valuesCount = int.Parse(obj.ToString());
                for (int i = 0; i < values.Count; i++)
                {
                    if (i < valuesCount)
                        values[i].IsSelected = true;
                    else
                        values[i].IsSelected = false;
                }
                SetSelections();
            }
        }


        #endregion

        #endregion

        #region Commands

        #region ChangeVisibilityCommand
        private RelayCommand changeVisibilityCommand;
        public RelayCommand ChangeVisibilityCommand
        {
            get => changeVisibilityCommand ?? (changeVisibilityCommand = new RelayCommand(obj =>
            {
                MoreVisibility = MoreVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            }));
        }
        #endregion

        #region SelectAllCommand
        private RelayCommand selectAllCommand;
        public RelayCommand SelectAllCommand
        {
            get => selectAllCommand ?? (selectAllCommand = new RelayCommand(obj =>
            {
                if (IsDeckPage)
                    SetAllDecks();
                else
                    SetAllWords();
            }));
        }
        #endregion

        #region SelectFirstCommand
        private RelayCommand selectFirstCommand;
        public RelayCommand SelectFirstCommand
        {
            get => selectFirstCommand ?? (selectFirstCommand = new RelayCommand(obj =>
            {
                if(IsDeckPage)
                    SetFirstDecks(obj);
                else
                    SetFirstWords(obj);
            }));
        }
        #endregion

        #region StartTestCommand
        private RelayCommand startTestCommand;
        public RelayCommand StartTestCommand
        {
            get => startTestCommand ?? (startTestCommand = new RelayCommand(obj =>
            {
                if(IsDeckPage)
                {
                    OpenSelectWordsPage();
                    Source = SELECT_WORDS_SOURCE;
                }
                else
                {
                    StartTest();
                }
            }));
        }
        #endregion

        #region CheckedChangeCommand
        private RelayCommand checkedChangeCommand;
        public RelayCommand CheckedChangeCommand
        {
            get => checkedChangeCommand ?? (checkedChangeCommand = new RelayCommand(obj =>
            {
                SetDecksSelections();
            }));
        }
        #endregion

        #region BackCommand
        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                Source = "SelectDecksPage.xaml";
                IsDeckPage = true;
                Navigate("Scripts/Views/SelectDecksPage.xaml");
            }));
        }
        #endregion

        #endregion

        #region Properties

        public ObservableCollection<Deck> Decks { get; set; } = new ObservableCollection<Deck>();

        #region MoreVisibility

        private Visibility moreVisibility = Visibility.Collapsed;
        /// <summary>
        /// <see cref="MoreVisibility"/> needs to set visibility of panel with select first N items.
        /// </summary>
        public Visibility MoreVisibility
        {
            get => moreVisibility;
            set
            {
                moreVisibility = value;
                OnPropertyChanged("MoreVisibility");
            }
        }
        #endregion

        #region IsDeckPage

        private bool isDeckPage = true;
        /// <summary>
        /// There's frame in TestPage and here's indicator of frame sorce: decks selections or words selections.
        /// </summary>
        public bool IsDeckPage
        {
            get => isDeckPage;
            set
            {
                isDeckPage = value;
                OnPropertyChanged("IsDeckPage");
            }
        }
        #endregion

        #region IsEmpty
        private bool isEmpty = true;
        /// <summary>
        /// Indicator of emptiness decks selections.
        /// </summary>
        public bool IsEmpty
        {
            get => isEmpty;
            set
            {
                isEmpty = value;
                OnPropertyChanged("IsEmpty");
            }
        }

        #endregion

        #region Source

        private string source = SELECT_DECKS_SOURCE;
        /// <summary>
        /// Source of frame which consists of: SelectDecksPage and SelectWordsPage.
        /// </summary>
        public string Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged("Source");
            }
        }
        #endregion

        #endregion
    }
}
