using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using typicalEnglish.Scripts.Models;

namespace typicalEnglish.Scripts.ViewModels.Converters
{
    /// <summary>
    /// Converter for changing word display: spelling or translation.
    /// </summary>
    [ValueConversion(typeof(Word), typeof(string))]
    class WordDisplayConverter: IValueConverter
    {
        #region Methods

        /// <summary>
        /// Get first translation of <paramref name="w"/>.
        /// </summary>
        /// <param name="w">Word to get translation.</param>
        public static string GetTranslation(Word w)
        {
            if (w.Translations.Count > 0)
                return w.Translations[0];
            return Question.EMPTY_TRANSLATIONS;
        }

        #endregion

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return GetTranslation(value as Word);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
