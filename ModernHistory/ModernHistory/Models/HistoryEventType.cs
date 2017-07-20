using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 历史事件类型
    /// 2017/06/30 fhr
    /// </summary>
    public class HistoryEventType : ModelBase<HistoryEventType>
    {
        private Int32 historyEventTypeId;
        private string historyEventTypeName;
        /// <summary>
        /// 历史事件类型编号
        /// </summary>
        public Int32 HistoryEventTypeId
        {
            get { return historyEventTypeId; }
            set
            {
                if (historyEventTypeId != value)
                {
                    historyEventTypeId = value;
                    NotifyPropertyChanged(p => p.HistoryEventTypeId);
                }
            }
        }
        /// <summary>
        /// 历史事件类型名称
        /// </summary>
        [Required(ErrorMessage = "HistoryEventType Name is required")]
        public string HistoryEventTypeName
        {
            get { return historyEventTypeName; }
            set
            {
                if (historyEventTypeName != value)
                {
                    historyEventTypeName = value;
                    NotifyPropertyChanged(p => p.HistoryEventTypeName);
                }
            }
        }
    }
}
