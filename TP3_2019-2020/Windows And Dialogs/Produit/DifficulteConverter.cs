using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TP3_2019_2020.Windows_And_Dialogs.Produit
{
    public class DifficulteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // double vert int
            int i = System.Convert.ToInt32(value);
            return i;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // int vers double
            double dbl = System.Convert.ToDouble(value);
            return dbl;
        }
    }

}

