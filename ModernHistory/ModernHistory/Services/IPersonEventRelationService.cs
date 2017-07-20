using ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services
{
    /// <summary>
    /// 名人事件关系接口
    /// 2017/07/11 fhr
    /// </summary>
    public interface IPersonEventRelationService
    {
        Task DeleteAsync(int id);
        Task<ObservableCollection<PersonEventRelation>> FindAllAsync();
        Task<PersonEventRelation> FindByIdAsync(int id);
        Task<PersonEventRelation> SaveAsync(PersonEventRelation personEventRelation);
        Task<ObservableCollection<PersonEventRelation>> SearchAsync(PersonEventRelationSearchModel searchModel);
        Task UpdateAsync(PersonEventRelation personEventRelation);
    }
}
