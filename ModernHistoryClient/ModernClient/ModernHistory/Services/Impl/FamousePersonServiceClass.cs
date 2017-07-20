using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;
using ModernHistory.Gloabl;
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

        public static readonly string UPDATE_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousPerson/Update";

        public static readonly string SEARCH_URL = WebApiConfig.WEBAPI_BASE_URL + "/Famous/Person/Search";

        public static readonly string DELETE_URL = WebApiConfig.WEBAPI_BASE_URL + "/FamousPerson/Delete";

        public async Task<ObservableCollection<FamousPerson>> FindAllAsync()
        {
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
