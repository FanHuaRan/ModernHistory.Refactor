using System;
namespace ModernHistory.Services
{
    /// <summary>
    /// 图片服务接口
    /// 2017/07/11 fhr
    /// </summary>
    interface IImageService
    {
        void UploadPersonImgAsync(int eventId, string pictureName);
        void UploadEventImgAsync(int personId, string pictureName);
    }
}
