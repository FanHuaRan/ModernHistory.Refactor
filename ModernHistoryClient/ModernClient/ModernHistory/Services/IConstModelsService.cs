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
    /// 常量数据服务 为了简单
    /// 2017/07/14 fhr
    /// </summary>
    public interface IConstModelsService
    {
        /// <summary>
        /// 名人类型
        /// </summary>
        ObservableCollection<FamousPersonType> FamousPersonTypes { get; }
        /// <summary>
        /// 事件类型
        /// </summary>
        ObservableCollection<HistoryEventType> HistoryEventTypes { get; }
        /// <summary>
        /// 省份
        /// </summary>
        ObservableCollection<string> Provinces { get; }
        /// <summary>
        /// 民族
        /// </summary>
        ObservableCollection<string> Nations { get; }


    }
}
