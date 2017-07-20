using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// 文件服务
      /// 2017/07/07 fhr
      /// </summary>
      public interface IPictureService
      {
            void SavePersonImagFile(MultipartFileData personImg, object personId);

            void SaveEventImageFile(MultipartFileData eventImg, object eventId);

            Stream GetPersonImageFile(object personId);

            Stream GetEventImageFile(object eventId);
      }
}
