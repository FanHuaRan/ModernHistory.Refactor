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
    /// HistoryEventType服务实现
    /// 2017/07/11 fhr
    /// </summary>
    public class HistoryEventTypeServiceClass:IHistoryEventTypeService
    {
        public static readonly string FindUrl = WebApiConfig.WEBAPI_BASE_Uri + "/HistoryEventType/Get";

        public async Task<ObservableCollection<HistoryEventType>> FindAllAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(FindUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<HistoryEventType>>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<HistoryEventType> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FindUrl, id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<HistoryEventType>();
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
