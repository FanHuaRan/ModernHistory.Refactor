using ModernHistory.Gloabl;
using ModernHistory.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ModernHistory.Converters
{
   [ValueConversion(typeof(int), typeof(string))]
    public class PersonImageConverter:IValueConverter
    {
       private static string ROOT = System.Environment.CurrentDirectory;
        public  object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var id = (int)value;
            var fileName=string.Format("{0}\\resources\\images\\persons\\{1}.jpg",ROOT,id);
            if(!File.Exists(fileName)){
                  fileName =string.Format("{0}\\resources\\images\\暂不支持.png",ROOT);
            }
            return fileName;
            // return HttpClientUtils.DownLoadImage(string.Format("{0}/{1}", WebApiConfig.WEBAPI_BASE_PERSON_PICURE, id)).Result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
