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
    /// 事件查询参数模型
    /// 2017/07/06 fhr
    /// </summary>
    public class EventSearchModel : ModelBase<EventSearchModel>
    {
        private String title;
        private DateTime? minOccurDate;
        private DateTime? maxOccurDate;
        private string province;
        private string place;
        private Int32? historyEventTypeId;

        /// <summary>
        /// 历史事件标题
        /// </summary>、
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
        /// 最小日期
        /// </summary>
        public DateTime? MinOccurDate
        {
            get { return minOccurDate; }

            set
            {
                if (minOccurDate != value)
                {
                    minOccurDate = value;
                    NotifyPropertyChanged(p => p.MinOccurDate);
                }
            }
        }

        /// <summary>
        /// 最大日期
        /// </summary>
        public DateTime? MaxOccurDate
        {
            get { return maxOccurDate; }

            set
            {
                if (maxOccurDate != value)
                {
                    maxOccurDate = value;
                    NotifyPropertyChanged(p => p.MaxOccurDate);
                }
            }
        }

        ///<summary>
        ///省份
        ///</summary>
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
        /// 事件类型
        /// </summary>
        public Int32? HistoryEventTypeId
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
    }
}
