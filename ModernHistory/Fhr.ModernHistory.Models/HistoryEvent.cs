using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
    /// <summary>
    /// 历史事件信息
    /// 2017/06/30 fhr
    /// </summary>
    public class HistoryEvent
    {
        /// <summary>
        /// 历史事件编号
        /// </summary>
        public Int32 HistoryEventId { get; set; }

        /// <summary>
        /// 历史事件标题
        /// </summary>、
        [Required(ErrorMessage = "Title is required")]
        [StringLength(30)]
        public String Title { get; set; }

        /// <summary>
        /// 事件详细信息
        /// </summary>
        [Required(ErrorMessage = "Detail is required")]
        [StringLength(1030)]
        public String Detail { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Required(ErrorMessage = "OccurDate is required")]
        public DateTime OccurDate { get; set; }

        ///<summary>
        ///省份
        ///</summary>
        [Required(ErrorMessage = "Province is required")]
        [StringLength(20)]
        public string Province { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        [Required(ErrorMessage = "Place is required")]
        public string Place { get; set; }

        /// <summary>
        /// 事件X坐标
        /// </summary>
        [Required(ErrorMessage = "Born longitude is required")]
        public double OccurX { get; set; }

        /// <summary>
        /// 事件Y坐标
        /// </summary>
        [Required(ErrorMessage = "Event Occur Latitude is required")]
        public double OccurY { get; set; }

        /// <summary>
        /// 历史事件类型编号
        /// </summary>
        [Required(ErrorMessage = "HistoryEventType Id is required")]
        public Int32 HistoryEventTypeId { get; set; }

        /// <summary>
        /// 历史事件类型
        /// </summary>
        public virtual HistoryEventType EventType { get; set; }
    }
}
