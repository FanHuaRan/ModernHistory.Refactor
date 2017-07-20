using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys;
using Fhr.ModernHistory.Repositorys.Impl;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// HistoryEventType服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class HistoryEventTypeServiceClass : IHistoryEventTypeService
      {
            private IHistoryEventTypeRepository historyEventTypeRepository = null;

            public HistoryEventTypeServiceClass(IHistoryEventTypeRepository historyEventTypeRepository)
            {
                  this.historyEventTypeRepository = historyEventTypeRepository;
            }

            public void Delete(object id)
            {
                  historyEventTypeRepository.DeleteById(id);
            }

            public IEnumerable<HistoryEventType> FindAll()
            {
                  return historyEventTypeRepository.FindAll();
            }

            public HistoryEventType FindById(object id)
            {
                  return historyEventTypeRepository.FindById(id);
            }

            public HistoryEventType FindByName(string name)
            {
                  return historyEventTypeRepository.FindByLinq(p => p.HistoryEventTypeName == name)
                                                                          .FirstOrDefault();
            }

            public HistoryEventType Save(HistoryEventType historyEventType)
            {
                  return historyEventTypeRepository.Save(historyEventType);
            }

            public void Update(HistoryEventType historyEventType)
            {
                   historyEventTypeRepository.Update(historyEventType);
            }
      }
}
