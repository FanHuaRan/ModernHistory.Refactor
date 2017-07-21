using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.DtoDoConverters
{
      /// <summary>
      /// 历史事件转换器
      /// 2017/07/21 fhr
      /// </summary>
      public class HistoryEventConverter
      {
            public static HistoryEventInfo ConvertToDto(HistoryEvent historyEvent, IEnumerable<Int32> personIds)
            {
                  if (historyEvent == null)
                  {
                        return null;
                  }
                  var historyInfo = new HistoryEventInfo()
                  {
                        Detail = historyEvent.Detail,
                        HistoryEventId = historyEvent.HistoryEventId,
                        OccurDate = historyEvent.OccurDate,
                        OccurX = historyEvent.OccurX,
                        OccurY = historyEvent.OccurY,
                        Place = historyEvent.Place,
                        Province = historyEvent.Province,
                        Title = historyEvent.Title,
                        PersonIds = personIds
                  };
                  return historyInfo;
            }

            public static HistoryEvent ConvertToDo(HistoryEventInfo historyEventInfo)
            {
                  if (historyEventInfo == null)
                  {
                        return null;
                  }
                  var history = new HistoryEvent()
                  {
                        Detail = historyEventInfo.Detail,
                        HistoryEventId = historyEventInfo.HistoryEventId,
                        OccurDate = historyEventInfo.OccurDate,
                        OccurX = historyEventInfo.OccurX,
                        OccurY = historyEventInfo.OccurY,
                        Place = historyEventInfo.Place,
                        Province = historyEventInfo.Province,
                        Title = historyEventInfo.Title
                  };
                  return history;
            }
      }
}
