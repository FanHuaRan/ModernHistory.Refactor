using ModernHistory.Gloabl;
using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services.Impl
{
    /// <summary>
    ///  PersonEventRelation服务实现
    ///  2017/07/11 fhr
    /// </summary>
    public class PersonEventRelationServiceClass : IPersonEventRelationService
    {
        public static readonly string FindUrl = WebApiConfig.WEBAPI_BASE_Uri + "/PersonEventRelation/Get";

        public static readonly string SaveUrl = WebApiConfig.WEBAPI_BASE_Uri + "/PersonEventRelation/Save";

        public static readonly string UpdateUrl = WebApiConfig.WEBAPI_BASE_Uri + "/PersonEventRelation/Update";

        public static readonly string SearchUrl = WebApiConfig.WEBAPI_BASE_Uri + "/PersonEventRelation/Search";

        public static readonly string DeleteUrl = WebApiConfig.WEBAPI_BASE_Uri + "/PersonEventRelation/Delete";

        public async Task<ObservableCollection<PersonEventRelation>> FindAllAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(FindUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<PersonEventRelation>>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<PersonEventRelation> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FindUrl, id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonEventRelation>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async void UpdateAsync(PersonEventRelation personEventRelation)
        {
            var address = string.Format("{0}/{1}",UpdateUrl, personEventRelation.PersonEventRelationId);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync<PersonEventRelation>(address, personEventRelation);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<PersonEventRelation> SaveAsync(PersonEventRelation personEventRelation, string pictureName)
        {
            //var address=string
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(SaveUrl, personEventRelation);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<PersonEventRelation>();
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
            var address = string.Format("{0}/{1}", DeleteUrl, id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(address, null);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<ObservableCollection<PersonEventRelation>> SearchAsync(PersonEventRelationSearchModel searchModel)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(SearchUrl, searchModel);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<PersonEventRelation>>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }
    }
}
