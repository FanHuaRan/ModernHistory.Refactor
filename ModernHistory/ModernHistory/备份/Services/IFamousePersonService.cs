using ModernHistory.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace ModernHistory.Services
{
    /// <summary>
    /// 名人服务接口
    /// </summary>
    interface IFamousePersonService
    {
        void DeleteAsync(int id);
        Task<ObservableCollection<FamousPerson>> FindAllAsync();
        Task<FamousPerson> FindByIdAsync(int id);
        Task<FamousPerson> SaveAsync(FamousPerson famousePerson, string pictureName);
        Task<ObservableCollection<FamousPerson>> SearchAsync(PersonSearchModel searchModel);
        void UpdateAsync(FamousPerson famousePerson);
    }
}
