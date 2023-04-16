using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTDemo.Converters
{
    public class FromUserToHorizontalOptionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0) return LayoutOptions.Start;

            if (values[0] == null) return LayoutOptions.Start;

            if (values[0].ToString() == "AI") return LayoutOptions.Start;

            return LayoutOptions.End;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
