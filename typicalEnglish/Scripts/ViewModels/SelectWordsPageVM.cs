using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels
{
    public class SelectWordsPageVM: INotifyPropertyChanged
    {
        #region Constructor

        public SelectWordsPageVM(ObservableCollection<Word> words)
        {
            Words = words;
        }
        
        #endregion

        #region Properties

        public ObservableCollection<Word> Words { get; set; }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
