using System;
using System.Threading.Tasks;
namespace ModernHistory.Services
{
    /// <summary>
    /// 图片服务接口
    /// 2017/07/11 fhr
    /// </summary>
    public interface IImageService
    {
        Task UploadPersonImgAsync(int eventId, string pictureName);
        Task UploadEventImgAsync(int personId, string pictureName);
    }
}
