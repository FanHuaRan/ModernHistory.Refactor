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
namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// 图片服务
    /// 2017/07/11 fhr
    /// </summary>
    public class ImageServiceClass : IImageService
    {
        public static readonly string UploadPersonImgUrl = WebApiConfig.WEBAPI_BASE_Uri + "/Image/UplodPersonImg";
        
        public static readonly string UploadEventImgUrl = WebApiConfig.WEBAPI_BASE_Uri + "/Image/UplodEventImg";

        public async void UploadPersonImgAsync(int personId,string pictureName)
        {
            var address = string.Format("{0}/{1}/", UploadPersonImgUrl, personId);
            await UploadImgAsync(pictureName, address);
        }
        public async void UploadEventImgAsync(int eventId, string pictureName)
        {
            var address = string.Format("{0}/{1}/", UploadEventImgUrl, eventId);
            UploadImgAsync(pictureName, address);
        }

        private static async void UploadImgAsync(string pictureName, string address)
        {
            using (var httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent(pictureName))
                using (var imgStream = File.Open(pictureName, FileMode.Open))
                {
                    content.Add(new StreamContent(imgStream));
                    var response = await httpClient.PostAsync(address, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                        throw new ApiErrorException(apiErrorModel);
                    }
                }
            }
        }
    }
}
