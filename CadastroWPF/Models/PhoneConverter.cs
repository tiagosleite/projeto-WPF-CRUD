using System;
using System.Windows.Data;

namespace CadastroWPF.Models
{
    internal class PhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double a = System.Convert.ToInt64(value);
            return a.ToString("(##)#####-####");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string str = value.ToString();
                return str.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            }
            return value;
        }
    }
}
