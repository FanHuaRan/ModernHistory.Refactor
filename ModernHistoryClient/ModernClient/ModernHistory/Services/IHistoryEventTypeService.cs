using Fhr.ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Services
{
    /// <summary>
    /// 历史事件类型服务接口
    /// </summary>
    public interface IHistoryEventTypeService
    {
        Task<ObservableCollection<HistoryEventType>> FindAllAsync();
        Task<HistoryEventType> FindByIdAsync(int id);
    }
}
