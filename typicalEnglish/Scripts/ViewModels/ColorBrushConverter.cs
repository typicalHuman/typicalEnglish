using System;
using System.Windows.Data;
using System.Windows.Media;

namespace typicalEnglish.Scripts.ViewModels
{
    /// <summary>
    /// Converter from color to brush.
    /// </summary>
    [ValueConversion(typeof(Brush), typeof(Color))]
    public class ColorBrushConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            Color color = (Color)value;
            Brush brush = (Brush)new BrushConverter().ConvertFrom(color.ToString());
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
