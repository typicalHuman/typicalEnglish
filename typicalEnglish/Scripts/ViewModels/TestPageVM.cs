using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using typicalEnglish.Scripts.Models;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;

namespace typicalEnglish.Scripts.ViewModels
{
    public class TestPageVM : INotifyPropertyChanged
    {
        public TestPageVM()
        {
            SetDecksSelections();
        }

        #region Methods

        #region SetSelections


        private void SetDecksSelections()
        {
            foreach (Deck d in App.DecksVM.Decks)
            {
                if (!Decks.Contains(d) && d.IsSelected)
                {
                    Decks.Add(d);
                }
                else if (Decks.Contains(d) && !d.IsSelected)
                {
                    Decks.Remove(d);
                }
            }
        }
        #endregion


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
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }


        private void OpenSelectWordsPage()
        {
            App.SelectWordVM = new SelectWordsPageVM(GetWordsFromDecks());
            IsDeckPage = false;
            Navigate("Scripts/Views/SelectWordsPage.xaml");
        }

        private void StartTest()
        {

        }


        #endregion

        #region SetAll

        private void SetAllDecks()
        {
            SetAllValues(App.DecksVM.Decks.Cast<TestValue>().ToList(), SetDecksSelections);
        }

        private void SetAllWords()
        {
            SetAllValues(App.SelectWordVM.Words.Cast<TestValue>().ToList(), () => { });
        }

        private void SetAllValues(List<TestValue> values, Action setSelections)
        {
            foreach (TestValue v in values)
                v.IsSelected = true;
            setSelections();
        }

        #endregion

        #region SetFirst

        private void SetFirstDecks(object obj)
        {
            SetFirst(obj, App.DecksVM.Decks.Cast<TestValue>().ToList(), SetDecksSelections);
        }

        private void SetFirstWords(object obj)
        {
            SetFirst(obj, App.SelectWordVM.Words.Cast<TestValue>().ToList(), () => { });
        }

        private void SetFirst(object obj, List<TestValue> values, Action setSelections)
        {
            int valuesCount = 0;
            if (int.TryParse(obj.ToString(), out valuesCount))
            {
                valuesCount = int.Parse(obj.ToString());
                for (int i = 0; i < values.Count; i++)
                {
                    if (i < valuesCount)
                         values[i].IsSelected = true;
                    else
                        values[i].IsSelected = false;
                }
                setSelections();
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
                {
                    SetAllDecks();
                }
                else
                {
                    SetAllWords();
                }
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
                {
                    SetFirstDecks(obj);
                }
                else
                {
                    SetFirstWords(obj);
                }
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
                    Source = "SelectWordsPage.xaml";
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

        #region Source

        private string source = "SelectDecksPage.xaml";
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

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
