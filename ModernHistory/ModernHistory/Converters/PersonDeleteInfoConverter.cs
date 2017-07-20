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
    /// 事件对象转换器
    /// 2017/07/13 fhr
    /// </summary>
     [ValueConversion(typeof(FamousPerson), typeof(string))]
    public class PersonDeleteInfoConverter
    {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             if (value == null)
             {
                 return "您还没有选择记录!!!";
             }
             var person=value as FamousPerson;
             return string.Format("您确认删除{0}吗", person.PersonName);
         }
    }
}
