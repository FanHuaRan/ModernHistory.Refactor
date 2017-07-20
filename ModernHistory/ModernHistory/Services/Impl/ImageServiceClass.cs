using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using ModernHistory.Gloabl;
using System.IO;
using ModernHistory.Models;
using ModernHistory.Utils;
namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// 图片服务
    /// 2017/07/11 fhr
    /// </summary>
    public class ImageServiceClass : IImageService
    {
        public static readonly string UPLOAD_PERSON_IMG_URL = WebApiConfig.WEBAPI_BASE_URL + "/Image/UplodPersonImg";

        public static readonly string UPLOAD_EVENT_IMG_URL = WebApiConfig.WEBAPI_BASE_URL + "/Image/UplodEventImg";

        public async Task UploadPersonImgAsync(int personId, string pictureName)
        {
            var address = string.Format("{0}/{1}/", UPLOAD_PERSON_IMG_URL, personId);
            await HttpClientUtils.UploadFileAsync(address, pictureName);
        }
        public async Task UploadEventImgAsync(int eventId, string pictureName)
        {
            var address = string.Format("{0}/{1}/", UPLOAD_EVENT_IMG_URL, eventId);
            await HttpClientUtils.UploadFileAsync(address, pictureName);
        }

    }
}
