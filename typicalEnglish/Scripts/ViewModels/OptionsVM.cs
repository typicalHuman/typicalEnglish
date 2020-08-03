using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace typicalEnglish.Scripts.ViewModels
{
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

        #endregion
    }
}
