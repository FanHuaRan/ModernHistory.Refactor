using ModernHistory.Gloabl;
using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// FamousePerson服务实现
    /// </summary>
    public class FamousePersonServiceClass : IFamousePersonService
    {

        public static readonly string FindUrl = WebApiConfig.WEBAPI_BASE_URL + "/FamousPerson/Get";

        public static readonly string SaveUrl = WebApiConfig.WEBAPI_BASE_URL + "/FamousPerson/Save";

        public static readonly string UpdateUrl = WebApiConfig.WEBAPI_BASE_URL + "/FamousePerson/Update";

        public static readonly string SearchUrl = WebApiConfig.WEBAPI_BASE_URL + "/Famouse/Person/Search";

        public static readonly string DeleteUrl = WebApiConfig.WEBAPI_BASE_URL + "/FamousePerson/Delete";

        public async  Task<ObservableCollection<FamousPerson>> FindAllAsync()
        {
            /*
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(FindUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsAsync<ObservableCollection<FamousPerson>>();
                    }
                    else
                    {
                        var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                        throw new ApiErrorException(apiErrorModel);
                    }
                }
                catch (Exception e)
                {
                    var apiErrorModel = new ApiErrorModel()
                    {
                        StatusCode=HttpStatusCode.NotFound,
                        Message="网络连接错误",
                        Code=3
                    };
                    throw new ApiErrorException(apiErrorModel);
                }
            }
             */
        }

        public async Task<FamousPerson> FindByIdAsync(int id)
        {
            var address =string.Format("{0}/{1}", FindUrl, id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<FamousPerson>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async void UpdateAsync(FamousPerson famousePerson)
        {
            var address = string.Format("{0}/{1}",UpdateUrl, famousePerson.FamousPersonId);
            using (var httpClient = new HttpClient())
            {
                var response =await httpClient.PostAsJsonAsync<FamousPerson>(address,famousePerson);
                if(!response.IsSuccessStatusCode)
                {
                    var apiErrorModel =await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<FamousPerson> SaveAsync(FamousPerson famousePerson,string pictureName)
        {
            //var address=string
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(SaveUrl, famousePerson);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<FamousPerson>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async void DeleteAsync(int id)
        {
            var address = string.Format("{0}/{1}", DeleteUrl,id);
            using (var httpClient = new HttpClient())
            {
                var response =  await httpClient.PostAsync(address,null);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<ObservableCollection<FamousPerson>> SearchAsync(PersonSearchModel searchModel)
        {
            using (var httpClient = new HttpClient())
            {
                var response =  await httpClient.PostAsJsonAsync(SearchUrl, searchModel);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<FamousPerson>>();
                }
                else
                {
                    var apiErrorModel =await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }
    }
}
