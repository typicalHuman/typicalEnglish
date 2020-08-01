using Newtonsoft.Json;
using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for define is item selected or not.
    /// </summary>
    public abstract class TestValue: BaseViewModel
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
    }
}
