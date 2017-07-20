using ModernHistory.Models;
using ModernHistory.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModernHistory.Converters
{
    /// <summary>
    /// FamousPersonType和ID转换器
    /// 2017/07/14 fhr
    /// </summary>
    [ValueConversion(typeof(int), typeof(HistoryEventType))]
    public class HistoryEventTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            var typeId = (int)value;
            return CommonConstViewModel.Instance.HistoryEventTypes.Where(p => p.HistoryEventTypeId == typeId).FirstOrDefault();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            var eventType=value as HistoryEventType;
            if (eventType != null)
            {
                return eventType.HistoryEventTypeId;
            }
            else
            {
                return -1;
            }
        }
    }
}
