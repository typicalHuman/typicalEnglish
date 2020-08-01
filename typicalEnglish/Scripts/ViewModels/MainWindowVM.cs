﻿using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// View model for window.
    /// </summary>
    public class MainWindowVM: BaseViewModel
    {
        #region Properties

        #region ResizeMode
        private ResizeMode resizeMode = ResizeMode.CanResizeWithGrip;
        public ResizeMode ResizeMode
        {
            get => resizeMode;
            set
            {
                resizeMode = value;
                OnPropertyChanged("ResizeMode");
            }
        }
        #endregion

        #region WindowState

        private WindowState windowState = WindowState.Normal;
        public WindowState WindowState
        {
            get => windowState;
            set
            {
                if(value == WindowState.Normal)
                {
                    WindowBorderThickness = new Thickness(1);
                    ResizeMode = ResizeMode.CanResizeWithGrip;
                }
                windowState = value;
                OnPropertyChanged("WindowState");
            }
        }

        #endregion

        #region WindowBorderThickness

        private Thickness windowBorderThickness = new Thickness(1);
        public Thickness WindowBorderThickness
        {
            get => windowBorderThickness;
            set
            {
                windowBorderThickness = value;
                OnPropertyChanged("WindowBorderThickness");
            }
        }

        #endregion

        #endregion

        #region Commands

        #region CloseCommand
        /// <summary>
        /// Action that should close main window.
        /// </summary>
        public Action CloseAction { get; set; }
        private RelayCommand closeCommand;
        /// <summary>
        /// Close window and save decks.
        /// </summary>
        public RelayCommand CloseCommand
        {
            get => closeCommand ?? (closeCommand = new RelayCommand(obj =>
            {
                JSONData.Save(App.DecksVM.Decks);
                CloseAction();
            }));

        }
        #endregion

        #region MaximizeCommand

        private RelayCommand maximizeCommand;
        public RelayCommand MaximizeCommand
        {
            get => maximizeCommand ?? (maximizeCommand = new RelayCommand(obj =>
            {
                WindowState = WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
                if(WindowState == WindowState.Maximized)
                {
                    ResizeMode = ResizeMode.NoResize;
                    WindowBorderThickness = new Thickness(0);
                }
            }));
        }
        #endregion

        #region MinimizeCommand
        private RelayCommand minimizeCommand;
        public RelayCommand MinimizeCommand
        {
            get => minimizeCommand ?? (minimizeCommand = new RelayCommand(obj =>
            {
                WindowState = WindowState.Minimized;
            }));
        }
        #endregion

        #region NavigateCommands
        private string lastPage { get; set; }

        /// <summary>
        /// Naviage to page with <paramref name="url"/>
        /// </summary>
        public void Navigate(string url)
        {
            if (url != lastPage)
            {
                Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
                lastPage = url;
            }
        }

        private RelayCommand pageNavigateCommand;
        public RelayCommand PageNavigateCommand
        {
            get
            {
                return pageNavigateCommand ?? (pageNavigateCommand = new RelayCommand(obj =>
                {
                    Navigate(obj.ToString());
                }));
            }
        }
        #endregion

        #endregion
    }
}
