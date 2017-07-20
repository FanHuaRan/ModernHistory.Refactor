using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// HistoryEventType服务接口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IHistoryEventTypeService
      {
            IEnumerable<HistoryEventType> FindAll();

            HistoryEventType FindById(Object id);

            void Update(HistoryEventType historyEventType);

            HistoryEventType Save(HistoryEventType historyEventType);

            void Delete(object id);

            HistoryEventType FindByName(string name);
      }
}
