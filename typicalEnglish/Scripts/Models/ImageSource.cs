using typicalEnglish.Scripts.ViewModels;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for tracking selected images.
    /// </summary>
    public class ImageSource : BaseViewModel
    {
        #region Properties

        #region Source
        private string source;
        /// <summary>
        /// Source of image.
        /// </summary>
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
        /// <summary>
        /// Is already selected image.
        /// </summary>
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
    }
}
