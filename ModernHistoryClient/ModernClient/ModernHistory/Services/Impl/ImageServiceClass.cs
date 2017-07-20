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
using System.Drawing;
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

        /// <summary>
        /// 名人图片基地址
        /// </summary>
        public static readonly string WEBAPI_BASE_PERSON_PICURE = "http://localhost:57759/api/Image/GetPersonImg";
        /// <summary>
        /// 事件图片基地址
        /// </summary>
        public static readonly string WEBAPI_BASE_EVENT_PICURE = "http://localhost:57759/api/Image/GetEventImg";

        public async Task UploadPersonImgAsync(int personId, string pictureName)
        {
            var address = string.Format("{0}/{1}", UPLOAD_PERSON_IMG_URL, personId);
            await HttpClientUtils.UploadFileAsync(address, pictureName);
        }
        public async Task UploadEventImgAsync(int eventId, string pictureName)
        {
            var address = string.Format("{0}/{1}", UPLOAD_EVENT_IMG_URL, eventId);
            await HttpClientUtils.UploadFileAsync(address, pictureName);
        }



        public async Task<Image> DownLoadPersonImgAsync(int personId)
        {
            string address = string.Format("{0}\\{1}", WEBAPI_BASE_PERSON_PICURE, personId);
            return await HttpClientUtils.DownLoadImage(address);
        }

        public async Task<Image> DownLoadEventImgAsync(int eventId)
        {
            string address = string.Format("{0}\\{1}", WEBAPI_BASE_EVENT_PICURE, eventId);
            return await HttpClientUtils.DownLoadImage(address);
        }



        public string GetPersonImgUrl(int personId)
        {
            throw new NotImplementedException();
        }

        public string GetEventImgUrl(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
