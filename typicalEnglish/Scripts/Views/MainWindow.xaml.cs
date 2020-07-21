using GalaSoft.MvvmLight.Messaging;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SetCulturalInfo();
            InitializeComponent();
            NavigationSetup();
            App.MainVM.CloseAction = Close;
        }

        #region Methods

        private void SetCulturalInfo()
        {
            CultureInfo ci = new CultureInfo("en-EN");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        #region DragMove

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Normal)
                    SetMaximized();
                else
                    SetNormal();
                WindowState = WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else
            {
                mRestoreForDragMove = WindowState == WindowState.Maximized;
                DragMove();
            }
        }

        private void SetNormal()
        {
            ResizeMode = ResizeMode.CanResizeWithGrip;
            BorderThickness = new Thickness(1);
        }

        private void SetMaximized()
        {
            ResizeMode = ResizeMode.NoResize;
            BorderThickness = new Thickness(0);
        }


        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (mRestoreForDragMove)
            {
                mRestoreForDragMove = false;

                var point = PointToScreen(e.MouseDevice.GetPosition(this));

                Left = point.X - (RestoreBounds.Width * 0.5);
                Top = point.Y;
                SetNormal();
                WindowState = WindowState.Normal;
                DragMove();
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mRestoreForDragMove = false;
        }

        private bool mRestoreForDragMove;

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized && ResizeMode == ResizeMode.CanResizeWithGrip)
            {
                WindowState = WindowState.Normal;
                SetMaximized();
                WindowState = WindowState.Maximized;
            }
        }
        #endregion


        private void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                if(!x.Url.Contains("Select"))
                   Frame1.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }

        #endregion

        #region Events

        protected override void OnClosed(EventArgs e)
        {
            App.MainVM.CloseCommand.Execute(null);
        }

        #endregion
    }
}
