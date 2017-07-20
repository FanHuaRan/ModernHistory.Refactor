using ModernHistory.Dto;
using ModernHistory.Exceptions;
using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Utils
{
    /// <summary>
    /// HttpClient辅助类
    /// 封装了基本的API方法，采用单例httpclient,速度更快
    /// 2017/07/12 fhr 
    /// </summary>
    public class HttpClientUtils
    {
        private static HttpClient httpClient = new HttpClient();
        /// <summary>
        /// 异步发起get请求，无返回值
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static async Task GetNoReturnAsync(string address)
        {
            try
            {
                var response = await httpClient.GetAsync(address);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
            catch (Exception er)
            {
                if (!(er is ApiErrorException))
                {
                    var apiErrorModel = new ApiErrorModel()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "网络连接错误",
                        Code = 3
                    };
                    throw new ApiErrorException(apiErrorModel);
                }
                else throw er;
            }
        }
        /// <summary>
        /// 异步发起get请求  有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string address)
        {
            try
            {
                var response = await httpClient.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<T>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
            catch (Exception er)
            {
                if (!(er is ApiErrorException))
                {
                    var apiErrorModel = new ApiErrorModel()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "网络连接错误",
                        Code = 3
                    };
                    throw new ApiErrorException(apiErrorModel);
                }
                else throw er;
            }
        }
        /// <summary>
        /// 异步发送post请求，带json数据，有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task<V> PostJsonAsync<T, V>(string address, T value)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(address, value);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<V>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
            catch (Exception er)
            {
                if (!(er is ApiErrorException))
                {
                    var apiErrorModel = new ApiErrorModel()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "网络连接错误",
                        Code = 3
                    };
                    throw new ApiErrorException(apiErrorModel);
                }
                else throw er;
            }
        }
        /// <summary>
        /// 异步发送post请求，带json数据，无返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task PostJsonNoReturnAsync<T>(string address, T value)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync(address, value);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
            catch (Exception er)
            {
                if (!(er is ApiErrorException))
                {
                    var apiErrorModel = new ApiErrorModel()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "网络连接错误",
                        Code = 3
                    };
                    throw new ApiErrorException(apiErrorModel);
                }
                else throw er;
            }
        }
        /// <summary>
        /// 异步发送post请求，无请求值和返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static async Task PostAsync(string address)
        {
            try
            {
                var response = await httpClient.PostAsync(address, null);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
            catch (Exception er)
            {
                if (!(er is ApiErrorException))
                {
                    var apiErrorModel = new ApiErrorModel()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Message = "网络连接错误",
                        Code = 3
                    };
                    throw new ApiErrorException(apiErrorModel);
                }
                else throw er;
            }
        }
        public static async Task UploadFileAsync(string address, string fileName)
        {
            using (var formContent = new MultipartFormDataContent())
           // using (var stream = File.Open(fileName, FileMode.Open))
            {
                try
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(fileName));
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = System.IO.Path.GetFileName(fileName)
                    };
                    formContent.Add(fileContent);
                    var response = await httpClient.PostAsync(address, formContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                        throw new ApiErrorException(apiErrorModel);
                    }
                }
                catch (Exception er)
                {
                    if (!(er is ApiErrorException))
                    {
                        var apiErrorModel = new ApiErrorModel()
                        {
                            StatusCode = HttpStatusCode.NotFound,
                            Message = "网络连接错误",
                            Code = 3
                        };
                        throw new ApiErrorException(apiErrorModel);
                    }
                    else throw er;
                }
            }
        }
        public static async Task<Image> DownLoadImage(string address)
        {
           var strem=await httpClient.GetStreamAsync(address);
           Image image = Image.FromStream(strem);
           return image;
        }
    }
}
