using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTDemo.Converters
{
    public class FromUserToBackgroudColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return Color.FromArgb("#d1d8e0");

            if (values[0] == null ) return Color.FromArgb("#d1d8e0");

            if (values[0].ToString() == "AI") return Color.FromArgb("#d1d8e0");

            return Color.FromArgb("#45aaf2");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
