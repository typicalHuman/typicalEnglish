using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace typicalEnglish.Scripts.Models
{
    public class MutableString: INotifyPropertyChanged
    {
        private string value;
        public string Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        #region Operators
        public static implicit operator MutableString(string str)
        {
            return new MutableString() { Value = str };
        }
        public static implicit operator string(MutableString mutStr)
        {
            return mutStr.Value;
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
