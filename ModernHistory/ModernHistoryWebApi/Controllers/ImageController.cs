using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Fhr.ModernHistory.Services;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// 图片下载控制器
      /// 参考：http://www.cnblogs.com/Kummy/p/3553799.html
      /// </summary>
      public class ImageController : ApiController
      {
            public IPictureService PictureService { get; set; }

            public ImageController(IPictureService pictureService)
            {
                  this.PictureService = pictureService;
            }
            [HttpPost]
            public  Task<Hashtable> UplodPersonImg(int id)
            {
                  // 检查该请求是否含有multipart/form-data    
                  if (!Request.Content.IsMimeMultipartContent())
                  {
                        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                  }
                  //临时存放路径
                  string root = HttpContext.Current.Server.MapPath("~/App_Data");
                  //MultipartFormData数据提供器
                  var provider = new MultipartFormDataStreamProvider(root);
                  //必须使用ContinueWith或者Task.new来处理文件 不然会死锁！！！
                  var task =Request.Content.ReadAsMultipartAsync(provider).ContinueWith<Hashtable>(p =>
                  {
                        if (provider.FileData.Count == 0)
                        {
                              throw new CustomerApiException(HttpStatusCode.BadRequest, 1, "没有文件");
                        }
                        //文件类型处理 暂时不做
                        //保存到本地
                        else
                        {
                              PictureService.SavePersonImagFile(provider.FileData[0], id);
                        }
                        //返回给客户端的数据 .....暂时没有
                        return new Hashtable();
                  });
                  return task;
            }

            [HttpPost]
            public Task<Hashtable> UploadEventImg(int id)
            {
                  // 检查该请求是否含有multipart/form-data    
                  if (!Request.Content.IsMimeMultipartContent())
                  {
                        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                  }
                  //临时存放路径
                  string root = HttpContext.Current.Server.MapPath("~/App_Data");
                  //MultipartFormData数据提供器
                  var provider = new MultipartFormDataStreamProvider(root);
                  var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith<Hashtable>(p =>
                  {
                        if (provider.FileData.Count == 0)
                        {
                              throw new CustomerApiException(HttpStatusCode.BadRequest, 1, "没有文件");
                        }
                        //文件类型处理 暂时不做
                        //保存到本地
                        else
                        {
                              PictureService.SaveEventImageFile(provider.FileData[0], id);
                        }
                        //返回给客户端的数据 .....暂时没有
                        return new Hashtable();
                  });
                  return task;
            }
            public HttpResponseMessage GetPersonImg(int id)
            {
                  var fs = PictureService.GetPersonImageFile(id);
                  if (fs == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "没有该图片");
                  }
                  var result = CreateImageResponseMessage(id, fs);
                  return result;
            }

            public HttpResponseMessage GetEventImg(int id)
            {
                  var fs = PictureService.GetEventImageFile(id);
                  if (fs == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "没有该事件");
                  }
                  var result = CreateImageResponseMessage(id, fs);
                  return result;
            }


            private static HttpResponseMessage CreateImageResponseMessage(int id, Stream fs)
            {
                  var result = new HttpResponseMessage(HttpStatusCode.OK);
                  result.Content = new StreamContent(fs);
                  result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                  result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                  result.Content.Headers.ContentDisposition.FileName = string.Format("{0}.jpg",id);
                  return result;
            }
      }
}