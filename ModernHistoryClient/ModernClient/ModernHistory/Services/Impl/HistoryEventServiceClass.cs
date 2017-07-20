using ModernHistory.Gloabl;
using Fhr.ModernHistory.Models;
using ModernHistory.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models.SearchModels;

namespace ModernHistory.Services.Impl
{
    /// <summary>
    /// HistoryEvent服务实现
    /// 2017/07/11 fhr
    /// </summary>
    public class HistoryEventServiceClass : IHistoryEventService
    {
        public static readonly string FIND_URL = WebApiConfig.WEBAPI_BASE_URL + "/HistoryEvent/Get";

        public static readonly string SAVE_URL = WebApiConfig.WEBAPI_BASE_URL + "/HistoryEvent/Save";

        public static readonly string UPDATE_URL = WebApiConfig.WEBAPI_BASE_URL + "/HistoryEvent/Update";

        public static readonly string SEARCH_URL = WebApiConfig.WEBAPI_BASE_URL + "/HistoryEvent/Search";

        public static readonly string DELETE_URL = WebApiConfig.WEBAPI_BASE_URL + "/HistoryEvent/Delete";

        public async Task<ObservableCollection<HistoryEvent>> FindAllAsync()
        {
            return await HttpClientUtils.GetAsync<ObservableCollection<HistoryEvent>>(FIND_URL);
        }

        public async Task<HistoryEvent> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FIND_URL, id);
            return await HttpClientUtils.GetAsync<HistoryEvent>(address);
        }

        public async Task UpdateAsync(HistoryEvent historyEvent)
        {
            var address = string.Format("{0}/{1}",UPDATE_URL,historyEvent.HistoryEventId);
            await HttpClientUtils.PostJsonNoReturnAsync<HistoryEvent>(address, historyEvent);
        }

        public async Task<HistoryEvent> SaveAsync(HistoryEvent historyEvent)
        {
            return await HttpClientUtils.PostJsonAsync<HistoryEvent, HistoryEvent>(SAVE_URL, historyEvent);
        }

        public async Task DeleteAsync(int id)
        {
            var address = string.Format("{0}/{1}", DELETE_URL, id);
            await HttpClientUtils.PostAsync(address);
        }

        public async Task<ObservableCollection<HistoryEvent>> SearchAsync(EventSearchModel searchModel)
        {
            return await HttpClientUtils.PostJsonAsync<EventSearchModel, ObservableCollection<HistoryEvent>>(SEARCH_URL, searchModel);    
        }

    }
}
