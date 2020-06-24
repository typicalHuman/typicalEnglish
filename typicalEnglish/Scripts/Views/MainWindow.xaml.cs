using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            InitializeComponent();
            NavigationSetup();
            App.MainVM.CloseAction = Close;
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
                Frame1.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }

    }
}
