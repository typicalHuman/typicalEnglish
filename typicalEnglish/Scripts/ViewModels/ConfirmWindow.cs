using System.Windows;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Class for working with confirm window.
    /// </summary>
    class ConfirmWindow
    {
        /// <summary>
        /// Open window with choice confirm.
        /// </summary>
        /// <returns>User's choice.</returns>
        public static string OpenConfirmWindow()
        {
            MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show(
                         "Are you sure?",
                         "Confirm dialog",
                         MessageBoxButton.YesNo,
                         (Style)Application.Current.FindResource("ConfirmBoxStyle")
                     );
            return result.ToString();
        }
    }
}
