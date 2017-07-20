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
    /// HistoryEvent服务实现
    /// 2017/07/11 fhr
    /// </summary>
    public class HistoryEventServiceClass : IHistoryEventService
    {
        public static readonly string FindUrl = WebApiConfig.WEBAPI_BASE_Uri + "/HistoryEvent/Get";

        public static readonly string SaveUrl = WebApiConfig.WEBAPI_BASE_Uri + "/HistoryEvent/Save";

        public static readonly string UpdateUrl = WebApiConfig.WEBAPI_BASE_Uri + "/HistoryEvent/Update";

        public static readonly string SearchUrl = WebApiConfig.WEBAPI_BASE_Uri + "/HistoryEvent/Search";

        public static readonly string DeleteUrl = WebApiConfig.WEBAPI_BASE_Uri + "/HistoryEvent/Delete";

        public async Task<ObservableCollection<HistoryEvent>> FindAllAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(FindUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<HistoryEvent>>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<HistoryEvent> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FindUrl, id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<HistoryEvent>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async void UpdateAsync(HistoryEvent historyEvent)
        {
            var address = string.Format("{0}/{1}",UpdateUrl,historyEvent.HistoryEventId);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync<HistoryEvent>(address, historyEvent);
                if (!response.IsSuccessStatusCode)
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<HistoryEvent> SaveAsync(HistoryEvent historyEvent, string pictureName)
        {
            //var address=string
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(SaveUrl, historyEvent);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<HistoryEvent>();
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

        public async Task<ObservableCollection<HistoryEvent>> SearchAsync(EventSearchModel searchModel)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(SearchUrl, searchModel);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<HistoryEvent>>();
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
