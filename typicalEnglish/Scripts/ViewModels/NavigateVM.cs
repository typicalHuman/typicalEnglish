using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace typicalEnglish.Scripts.ViewModels
{
    public class NavigateVM : ViewModelBase
    {
        /// <summary>
        /// Navigate to <paramref name="url"/>.
        /// </summary>
        /// <param name="url">Url of page.</param>
        public void Navigate(string url)
        {
            Messenger.Default.Send(new NavigateArgs(url));
        }
    }
}
