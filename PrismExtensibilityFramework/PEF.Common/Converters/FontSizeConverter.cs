
namespace PEF.Common.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class FontSizeConverter : IValueConverter
    {
        private const double default_font_size = 14.666;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try { return value == null ? default_font_size : value is double ? System.Convert.ToDouble(value) * 96 / 72 : default_font_size; }
            catch { return default_font_size; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
