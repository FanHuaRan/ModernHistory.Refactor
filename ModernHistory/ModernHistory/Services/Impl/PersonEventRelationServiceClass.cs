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
    ///  PersonEventRelation服务实现
    ///  2017/07/11 fhr
    /// </summary>
    public class PersonEventRelationServiceClass : IPersonEventRelationService
    {
        public static readonly string FIND_URL = WebApiConfig.WEBAPI_BASE_URL + "/PersonEventRelation/Get";

        public static readonly string SAVE_URL = WebApiConfig.WEBAPI_BASE_URL + "/PersonEventRelation/Save";

        public static readonly string UPDATE_URL = WebApiConfig.WEBAPI_BASE_URL + "/PersonEventRelation/Update";

        public static readonly string SEARCH_URL = WebApiConfig.WEBAPI_BASE_URL + "/PersonEventRelation/Search";

        public static readonly string DELETE_URL = WebApiConfig.WEBAPI_BASE_URL + "/PersonEventRelation/Delete";

        public async Task<ObservableCollection<PersonEventRelation>> FindAllAsync()
        {
            return await HttpClientUtils.GetAsync<ObservableCollection<PersonEventRelation>>(FIND_URL);
        }

        public async Task<PersonEventRelation> FindByIdAsync(int id)
        {
            var address = string.Format("{0}/{1}", FIND_URL, id);
            return await HttpClientUtils.GetAsync<PersonEventRelation>(address);
        }

        public async Task UpdateAsync(PersonEventRelation personEventRelation)
        {
            var address = string.Format("{0}/{1}",UPDATE_URL, personEventRelation.PersonEventRelationId);
            await HttpClientUtils.PostJsonNoReturnAsync<PersonEventRelation>(address, personEventRelation);
        }

        public async Task<PersonEventRelation> SaveAsync(PersonEventRelation personEventRelation)
        {
            return await HttpClientUtils.PostJsonAsync<PersonEventRelation, PersonEventRelation>(SAVE_URL, personEventRelation);
        }

        public async Task DeleteAsync(int id)
        {
            var address = string.Format("{0}/{1}", DELETE_URL, id);
            await HttpClientUtils.PostAsync(address);
        }

        public async Task<ObservableCollection<PersonEventRelation>> SearchAsync(PersonEventRelationSearchModel searchModel)
        {
            return await HttpClientUtils.PostJsonAsync<PersonEventRelationSearchModel, ObservableCollection<PersonEventRelation>>(SEARCH_URL, searchModel);    
        }
    }
}
