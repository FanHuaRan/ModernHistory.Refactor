using ModernHistory.Gloabl;
using ModernHistory.Models;
using ModernHistory.Utils;
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
        public static readonly string FIND_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousPersonType/Get";

        public async Task<ObservableCollection<FamousPersonType>> FindAllAsync()
        {
            return await HttpClientUtils.GetAsync<ObservableCollection<FamousPersonType>>(FIND_URL);
        }

        public async Task<FamousPersonType> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FIND_URL, id);
            return await HttpClientUtils.GetAsync<FamousPersonType>(address);
        }
    }
}
