using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace typicalEnglish.Scripts.Models
{
    public class ImageSource : INotifyPropertyChanged
    {
        #region Properties

        #region Source
        private string source;
        public string Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged("Source");
            }
        }
        #endregion

        #region IsSelected

        private bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #endregion

        #region Operators


        public static implicit operator ImageSource(string str)
        {
            return new ImageSource() { Source = str };
        }
        public static implicit operator string(ImageSource imSource)
        {
            return imSource.Source;
        }


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
