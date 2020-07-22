﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using typicalEnglish.Scripts.Models;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;

namespace typicalEnglish.Scripts.ViewModels
{
    public class TestPageVM : INotifyPropertyChanged
    {
        public TestPageVM()
        {
            SetSelections();
        }

        #region Methods

        private void SetSelections()
        {
            foreach (Deck d in App.DecksVM.Decks)
            {
                if (!Decks.Contains(d) && d.IsSelected)
                {
                    Decks.Add(d);
                }
                else if(Decks.Contains(d) && !d.IsSelected)
                {
                    Decks.Remove(d);
                }
            }
        }

        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }

        private ObservableCollection<Word> GetWordsFromDecks()
        {
            List<Word> words = new List<Word>();
            foreach (Deck deck in App.DecksVM.Decks)
                if (deck.IsSelected)
                    words.AddRange(deck.Words);
            return new ObservableCollection<Word>(words);
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
                foreach (Deck deck in App.DecksVM.Decks)
                    deck.IsSelected = true;
                SetSelections();
            }));
        }
        #endregion

        #region SelectFirstCommand
        private RelayCommand selectFirstCommand;
        public RelayCommand SelectFirstCommand
        {
            get => selectFirstCommand ?? (selectFirstCommand = new RelayCommand(obj =>
            {
                int decksCount = 0; 
                if(int.TryParse(obj.ToString(), out decksCount))
                {
                    decksCount = int.Parse(obj.ToString());
                    for (int i = 0; i < App.DecksVM.Decks.Count; i++)
                    {
                        if (i < decksCount)
                            App.DecksVM.Decks[i].IsSelected = true;
                        else
                            App.DecksVM.Decks[i].IsSelected = false;
                    }
                    SetSelections();

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
                SetSelections();
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
