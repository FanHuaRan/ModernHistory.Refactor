using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModernHistory.Converters
{
    /// <summary>
    /// 事件删除信息确认转换器
    /// 2017/07/13 fhr
    /// </summary>
     [ValueConversion(typeof(HistoryEvent), typeof(string))]
    public class EventDeleteInfoConverter
    {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             if (value == null)
             {
                 return "您还没有选择记录!!!";
             }
             var events = value as HistoryEvent;
             return string.Format("您确认删除'{0}'吗", events.Title);
         }
    }
}
