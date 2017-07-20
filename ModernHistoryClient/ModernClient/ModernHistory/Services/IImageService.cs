using System;
using System.Drawing;
using System.Threading.Tasks;
namespace ModernHistory.Services
{
    /// <summary>
    /// 图片服务接口
    /// 2017/07/11 fhr
    /// </summary>
    public interface IImageService
    {
        Task UploadPersonImgAsync(int personId, string pictureName);
        Task UploadEventImgAsync(int eventId, string pictureName);

        Task<Image> DownLoadPersonImgAsync(int personId);

        Task<Image> DownLoadEventImgAsync(int eventId);

        string GetPersonImgUrl(int personId);

        string GetEventImgUrl(int eventId);

    }
}
