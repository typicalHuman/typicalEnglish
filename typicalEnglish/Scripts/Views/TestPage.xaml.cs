using GalaSoft.MvvmLight.Messaging;
using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Views
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            NavigationSetup();
        }

        #region Events
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        #region Methods
        private void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                Frame2.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }


        #endregion


    }
}
