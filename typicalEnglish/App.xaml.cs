using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        public App()
        {
            MainVM = new MainWindowVM();
        }

    }
}
