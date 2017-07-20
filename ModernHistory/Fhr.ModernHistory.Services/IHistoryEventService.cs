using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Dtos.SearchModels;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// HistoryEvent服务借口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IHistoryEventService
      {
            IEnumerable<HistoryEventInfo> FindAll();

            HistoryEventInfo FindById(Object id);

            void Update(HistoryEventInfo HistoryEvent);

            HistoryEventInfo Save(HistoryEventInfo historyEvent);

            void Delete(object id);

            IEnumerable<HistoryEventInfo> Search(EventSearchModel searchModel);
      }
}
