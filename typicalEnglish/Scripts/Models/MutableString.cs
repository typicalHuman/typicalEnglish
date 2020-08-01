using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for update string value in binding.
    /// </summary>
    public class MutableString: BaseViewModel
    {
        private string value;
        /// <summary>
        /// Value for updating.
        /// </summary>
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

    }
}
