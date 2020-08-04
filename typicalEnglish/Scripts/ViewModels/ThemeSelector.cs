using System;
using System.Windows;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Class for selecting application theme.
    /// </summary>
    class ThemeSelector
    {
        #region Constants

        private const string DARK_THEME_PATH = "Resources/Themes/DarkTheme.xaml";
        private const string LIGHT_THEME_PATH = "Resources/Themes/LightTheme.xaml";

        private const int THEME_INDEX = 0;

        #endregion

        #region Enums

        public enum Theme
        {
            Light, Dark
        }

        #endregion

        #region Methods
        /// <param name="relativePath">Local path to resource.</param>
        public static void SelectTheme(string relativePath)
        {
            Application.Current.Resources.MergedDictionaries[THEME_INDEX].Source = new Uri(relativePath, UriKind.Relative);
        }

        /// <param name="theme">Abstract value for theme.</param>
        public static void SelectTheme(Theme theme)
        {
            string path = GetPath(theme);
            SelectTheme(path);
        }

        private static string GetPath(Theme theme)
        {
            if (theme == Theme.Dark)
                return DARK_THEME_PATH;
            return LIGHT_THEME_PATH;
        }
        #endregion

    }
}
