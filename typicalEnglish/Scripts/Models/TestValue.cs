using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace typicalEnglish.Scripts.Models
{
    public abstract class TestValue: INotifyPropertyChanged
    {
        #region IsSelected
        private bool isSelected = false;
        [JsonIgnore]
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

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
