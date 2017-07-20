using ModernHistory.Gloabl;
using ModernHistory.Models;
using ModernHistory.Utils;
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

        public static readonly string FIND_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousPerson/Get";

        public static readonly string SAVE_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousPerson/Save";

        public static readonly string UPDATE_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousePerson/Update";

        public static readonly string SEARCH_URL = WebApiConfig.WEBAPI_BASE_URL + "/Famouse/Person/Search";

        public static readonly string DELETE_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousePerson/Delete";

        public async Task<ObservableCollection<FamousPerson>> FindAllAsync()
        {
            #region 测试
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(FIND_URL);
                    if (response.IsSuccessStatusCode)
                    {
                        var result=await response.Content.ReadAsAsync<ObservableCollection<Fhr.ModernHistory.Models.FamousPerson>>();
                        var result2 = await response.Content.ReadAsAsync<ObservableCollection<FamousPerson>>();

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
            #endregion
            return await  HttpClientUtils.GetAsync<ObservableCollection<FamousPerson>>(FIND_URL);
        }

        public async Task<FamousPerson> FindByIdAsync(int id)
        {
            var address =string.Format("{0}/{1}", FIND_URL, id);
            return await HttpClientUtils.GetAsync<FamousPerson>(address);
        }

        public async Task UpdateAsync(FamousPerson famousePerson)
        {
            var address = string.Format("{0}/{1}",UPDATE_URL, famousePerson.FamousPersonId);
            await HttpClientUtils.PostJsonNoReturnAsync<FamousPerson>(address,famousePerson);
        }

        public async Task<FamousPerson> SaveAsync(FamousPerson famousePerson)
        {
            return await HttpClientUtils.PostJsonAsync<FamousPerson, FamousPerson>(SAVE_URL, famousePerson);
        }

        public async Task DeleteAsync(int id)
        {
            var address = string.Format("{0}/{1}", DELETE_URL,id);
            await HttpClientUtils.PostAsync(address);
        }

        public async Task<ObservableCollection<FamousPerson>> SearchAsync(PersonSearchModel searchModel)
        {
            return await HttpClientUtils.PostJsonAsync<PersonSearchModel, ObservableCollection<FamousPerson>>(SEARCH_URL, searchModel);    
        }
    }
}
