using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.Calculadora.Converters
{
    public class DecimalToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal typedValue = (decimal)value;
            return typedValue.ToString(culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string typedValue = (string)value;
            return decimal.Parse(typedValue, culture);
        }
    }
}
