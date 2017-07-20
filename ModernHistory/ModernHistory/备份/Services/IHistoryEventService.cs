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
    /// 历史事件服务接口
    /// 2017/07/11 
    /// </summary>
    public interface IHistoryEventService
    {
        void DeleteAsync(int id);
        Task<ObservableCollection<HistoryEvent>> FindAllAsync();
        Task<HistoryEvent> FindByIdAsync(int id);
        Task<HistoryEvent> SaveAsync(HistoryEvent historyEvent, string pictureName);
        Task<ObservableCollection<HistoryEvent>> SearchAsync(EventSearchModel searchModel);
        void UpdateAsync(HistoryEvent historyEvent);
    }
}
