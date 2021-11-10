using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ChinookUi.Converter
{
    public class MillisecondConverter : IValueConverter
    {
        // wandelt Milliseconds in einen lesbaren String
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int milliseconds = (int)value;
                // mm:ss,000
                int seconds = milliseconds / 1000;
                int ms = milliseconds - seconds*1000;
                int min = seconds / 60;
                int rs = seconds - min * 60;

                return $"{min}:{rs},{ms}";

            }
            catch (Exception)
            {

                return null;
            }
        }

        // wandelt eine ausführliche Zeitangabe in einen Integer-Milliseconds-Wert
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
