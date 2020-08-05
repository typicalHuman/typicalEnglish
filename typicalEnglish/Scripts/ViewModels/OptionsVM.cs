using Newtonsoft.Json;
using System.Diagnostics;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Application options.
    /// </summary>
    public class OptionsVM: BaseViewModel
    {
        #region Commands
        
        #region GotoRepositoryCommand
        private RelayCommand gotoRepositoryCommand;
        public RelayCommand GotoRepositoryCommand
        {
            get => gotoRepositoryCommand ?? (gotoRepositoryCommand = new RelayCommand(obj =>
            {
                Process.Start(obj.ToString());
            }));
        }

        #endregion

        #region DeleteAllDataCommand

        private RelayCommand deleteAllDataCommand;
        public RelayCommand DeleteAllDataCommand
        {
            get => deleteAllDataCommand ?? (deleteAllDataCommand = new RelayCommand(obj =>
            {
                string result = ConfirmWindow.OpenConfirmWindow();
                if (result == "Yes")
                {
                    App.DecksVM.Decks.Clear();
                    App.TestPageVM = new TestPageVM();
                    JSONData.Save(App.DecksVM.Decks);
                }
            }));
        }

        #endregion

        #endregion

        #region Properties

        #region IsDarkMode

        private bool isDarkMode;
        public bool IsDarkMode
        {
            get => isDarkMode;
            set
            {
                if (value)
                    ThemeSelector.SelectTheme("Resources/Themes/DarkTheme.xaml");
                else
                    ThemeSelector.SelectTheme(ThemeSelector.Theme.Light);
                isDarkMode = value;
                JSONData.SaveConfig(isDarkMode);
                var a = JSONData.GetConfig();
                OnPropertyChanged("IsDarkMode");
            }
        }

        #endregion

        #endregion
    }
}
