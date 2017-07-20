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
    /// FamousPersonType服务实现
    /// </summary>
    public class FamousPersonTypeServiceClass:IFamousPersonTypeService
    {
        public static readonly string FindUrl = WebApiConfig.WEBAPI_BASE_Uri + "/FamousPersonType/Get";

        public async Task<ObservableCollection<FamousPersonType>> FindAllAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(FindUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ObservableCollection<FamousPersonType>>();
                }
                else
                {
                    var apiErrorModel = await response.Content.ReadAsAsync<ApiErrorModel>();
                    throw new ApiErrorException(apiErrorModel);
                }
            }
        }

        public async Task<FamousPersonType> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FindUrl, id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(address);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<FamousPersonType>();
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
