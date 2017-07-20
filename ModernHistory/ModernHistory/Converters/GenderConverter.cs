using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModernHistory.Converters
{
    /// <summary>
    /// 性别转换器
    /// 2017/07/13 fhr
    /// </summary>
    [ValueConversion(typeof(byte), typeof(string))]
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var byteValue = (byte)value;
            if (byteValue == 0)
            {
                return "男";
            }
            return "女";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var strValue = (string)value;
            if (strValue == "男")
            {
                return 0;
            }
            return 1;
        }
    }
}
