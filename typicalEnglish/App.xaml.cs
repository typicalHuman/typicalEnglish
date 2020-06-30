using System.Windows;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        public static MainWindowVM MainVM { get; set; }
        public static DecksPageVM DecksVM { get; set; }
        public static DeckPageVM DeckVM { get; set; }
        public App()
        {
            MainVM = new MainWindowVM();
            DecksVM = new DecksPageVM();
        }

    }
}
