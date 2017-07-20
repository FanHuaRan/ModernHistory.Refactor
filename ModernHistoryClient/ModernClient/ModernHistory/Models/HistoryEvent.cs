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
    /// 历史事件信息
    /// 2017/06/30 fhr
    /// </summary>
    public class HistoryEvent : ModelBase<HistoryEvent>
    {
        private Int32 historyEventId;
        private String title;
        private String detail;
        private DateTime occurDate;
        private string province;
        private string place;
        private double occurX;
        private double occurY;
        private Int32 historyEventTypeId;
        private HistoryEventType eventType;

        /// <summary>
        /// 历史事件编号
        /// </summary>
        public Int32 HistoryEventId
        {
            get { return historyEventId; }
            set
            {
                if (historyEventId != value)
                {
                    historyEventId = value;
                    NotifyPropertyChanged(p => p.HistoryEventId);
                }
            }
        }

        /// <summary>
        /// 历史事件标题
        /// </summary>、
        [Required(ErrorMessage = "Title is required")]
        [StringLength(30)]
        public String Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    NotifyPropertyChanged(p => p.Title);
                }
            }
        }

        /// <summary>
        /// 事件详细信息
        /// </summary>
        [Required(ErrorMessage = "Detail is required")]
        [StringLength(1030)]
        public String Detail
        {
            get { return detail; }
            set
            {
                if (detail != value)
                {
                    detail = value;
                    NotifyPropertyChanged(p => p.Detail);
                }
            }
        }

        /// <summary>
        /// 日期
        /// </summary>
        [Required(ErrorMessage = "OccurDate is required")]
        public DateTime OccurDate
        {
            get { return occurDate; }
            set
            {
                if (occurDate != value)
                {
                    occurDate = value;
                    NotifyPropertyChanged(p => p.OccurDate);
                }
            }
        }

        ///<summary>
        ///省份
        ///</summary>
        [Required(ErrorMessage = "Province is required")]
        [StringLength(20)]
        public string Province
        {
            get { return province; }
            set
            {
                if (province != value)
                {
                    province = value;
                    NotifyPropertyChanged(p => p.Province);
                }
            }
        }

        /// <summary>
        /// 地点
        /// </summary>
        [Required(ErrorMessage = "Place is required")]
        public string Place
        {
            get { return place; }
            set
            {
                if (place != value)
                {
                    place = value;
                    NotifyPropertyChanged(p => p.Place);
                }
            }
        }

        /// <summary>
        /// 事件X坐标
        /// </summary>
        [Required(ErrorMessage = "Event  Occur longitude is required")]
        public double OccurX
        {
            get { return occurX; }
            set
            {
                if (occurX != value)
                {
                    occurX = value;
                    NotifyPropertyChanged(p => p.OccurX);
                }
            }
        }

        /// <summary>
        /// 事件Y坐标
        /// </summary>
        [Required(ErrorMessage = "Event Occur Latitude is required")]
        public double OccurY
        {
            get { return occurY; }
            set
            {
                if (occurY != value)
                {
                    occurY = value;
                    NotifyPropertyChanged(p => p.OccurY);
                }
            }
        }

        /// <summary>
        /// 历史事件类型编号
        /// </summary>
        [Required(ErrorMessage = "HistoryEventType Id is required")]
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
        /// 历史事件类型
        /// </summary>
        public virtual HistoryEventType EventType
        {
            get { return eventType; }
            set
            {
                if (eventType != value)
                {
                    eventType = value;
                    NotifyPropertyChanged(p => p.EventType);
                }
            }
        }
    }
}