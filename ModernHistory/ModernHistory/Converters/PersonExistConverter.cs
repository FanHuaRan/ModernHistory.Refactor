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
    /// 人员对象转换器
    /// 2017/07/13 fhr
    /// </summary>
     [ValueConversion(typeof(FamousPerson), typeof(bool))]
    public class PersonExistConverter
    {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return value != null;
         }
    }
}
