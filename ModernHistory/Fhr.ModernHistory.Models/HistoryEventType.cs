using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
    /// <summary>
    /// 历史事件类型
    /// 2017/06/30 fhr
    /// </summary>
    public class HistoryEventType
    {
        /// <summary>
        /// 历史事件类型编号
        /// </summary>
        public Int32 HistoryEventTypeId { get; set; }
        /// <summary>
        /// 历史事件类型名称
        /// </summary>
        [Required(ErrorMessage = "HistoryEventType Name is required")]
        public string HistoryEventTypeName { get; set; }
    }
}
