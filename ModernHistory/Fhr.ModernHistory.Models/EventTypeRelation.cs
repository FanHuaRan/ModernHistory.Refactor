using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
       /// <summary>
      /// 事件类型类型关系
      /// 2017/07/20 fhr
      /// </summary>
      public class EventTypeRelation
      {
            public Int32 EventTypeRelationId { get; set; }
            
             public Int32 HistoryEventId { get; set; }

            public Int32 HistoryEventTypeId { get; set; }
      }
}
