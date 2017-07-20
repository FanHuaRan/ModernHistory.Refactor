using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Dtos.SearchModels
{
      /// <summary>
      /// 事件查询参数模型
      /// 2017/07/06 fhr
      /// </summary>
      public class EventSearchModel
      {
            /// <summary>
            /// 历史事件标题
            /// </summary>、
            public String Title { get; set; }

            /// <summary>
            /// 最小日期
            /// </summary>
            public DateTime? MinOccurDate { get; set; }

            /// <summary>
            /// 最大日期
            /// </summary>
            public DateTime? MaxOccurDate { get; set; }

            ///<summary>
            ///省份
            ///</summary>
            public string Province { get; set; }

            /// <summary>
            /// 地点
            /// </summary>
            public string Place { get; set; }

            /// <summary>
            /// 名人编号
            /// </summary>
            public Int32? FamousPersonId { get; set; }

      }
}
