using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
//using System.Windows.Data;

namespace ModernHistory.Converters
{
   [ValueConversion(typeof(HistoryEvent), typeof(bool))]
    public class EventExistConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null;
        }
    }
}
