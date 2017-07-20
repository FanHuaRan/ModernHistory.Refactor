using ModernHistory.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace ModernHistory.Services
{
    /// <summary>
    /// 名人服务接口
    /// </summary>
    public interface IFamousePersonService
    {
        Task DeleteAsync(int id);
        Task<ObservableCollection<FamousPerson>> FindAllAsync();
        Task<FamousPerson> FindByIdAsync(int id);
        Task<FamousPerson> SaveAsync(FamousPerson famousePerson);
        Task<ObservableCollection<FamousPerson>> SearchAsync(PersonSearchModel searchModel);
        Task UpdateAsync(FamousPerson famousePerson);
    }
}
