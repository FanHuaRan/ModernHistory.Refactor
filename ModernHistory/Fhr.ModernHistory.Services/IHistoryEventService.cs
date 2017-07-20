using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// HistoryEvent服务借口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IHistoryEventService
      {
            IEnumerable<HistoryEvent> FindAll();

            HistoryEvent FindById(Object id);

            void Update(HistoryEvent HistoryEvent);

            HistoryEvent Save(HistoryEvent historyEvent);

            void Delete(object id);

            IEnumerable<HistoryEvent> Search(EventSearchModel searchModel);
      }
}
