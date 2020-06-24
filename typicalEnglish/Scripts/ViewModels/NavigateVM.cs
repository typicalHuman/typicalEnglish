using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace typicalEnglish.Scripts.ViewModels
{
    public class NavigateVM : ViewModelBase
    {
        public NavigateVM()
        {

        }

        public string Title { get; set; }
        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }
    }
}
