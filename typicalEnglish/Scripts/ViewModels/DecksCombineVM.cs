using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typicalEnglish.Scripts.ViewModels
{
    public class DecksCombineVM: BaseViewModel
    {
        #region Commands

        #region BackCommand
        private RelayCommand backCommand;
        /// <summary>
        /// Back to options page.
        /// </summary>
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(obj =>
            {
                App.MainVM.Navigate(Paths.OPTIONS_PAGE);
            }));
        }
        #endregion


        #endregion
    }
}
