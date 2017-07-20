using Fhr.ModernHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Repositorys.Contexts;
using System.Data.Entity;
namespace Fhr.ModernHistory.Repositorys.Impl
{
    /// <summary>
    /// HistoryEvent仓库实现
    /// 2017/07/01 fhr
    /// </summary>
    public class HistoryEventRepositoryClass : BaseRepositoryClass<HistoryEvent>,IHistoryEventRepository
    {
            public override IEnumerable<HistoryEvent> FindAll()
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.HistoryEvents.Include(p =>p.EventType)
                                                                         .Select(p => p)
                                                                         .ToList();
                  }
            }

            public override HistoryEvent FindById(object id)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.HistoryEvents.Include(p => p.EventType)
                                                                         .Where(p => p.HistoryEventId == (int)id)
                                                                         .Select(p => p)
                                                                         .FirstOrDefault();
                  }
            }

            public override IEnumerable<HistoryEvent> FindByLinq(Func<HistoryEvent, bool> expression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.HistoryEvents.Include(p => p.EventType)
                                                                         .Where(expression)
                                                                         .Select(p => p)
                                                                         .ToList();
                  }
            }

            public override IEnumerable<V> FindBySelect<V>(Func<HistoryEvent, V> selectExpression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.HistoryEvents.Include(p => p.EventType)
                                                                         .Select(selectExpression)
                                                                         .ToList();
                  }
            }

            public override IEnumerable<object> FindByWhereAndSelect(Func<HistoryEvent, bool> whereExpression, Func<HistoryEvent, object> selectExpression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.HistoryEvents.Include(p => p.EventType)
                                                                         .Where(whereExpression)
                                                                         .Select(selectExpression)
                                                                          .ToList();
                  }
            }
      }
}
