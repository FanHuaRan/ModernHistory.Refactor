using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Fhr.ModernHistory.Repositorys.Impl
{
      /// <summary>
      /// FamousPerson仓库实现
      /// 2017/07/01 fhr
      /// </summary>
      public class FamousPersonRepositoryClass : BaseRepositoryClass<FamousPerson>, IFamousPersonRepository
      {
            /// <summary>
            /// 重写FindAll，让其支持PersonType属性的加载
            /// </summary>
            /// <returns></returns>
            public override IEnumerable<FamousPerson> FindAll()
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.FamousPersons.Include(p => p.PersonType)
                                                                         .Select(p => p)
                                                                         .ToList();
                  }
            }

            public override FamousPerson FindById(object id)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.FamousPersons.Include(p => p.PersonType)
                                                                         .Where(p => p.FamousPersonId == (int)id)
                                                                         .Select(p => p)
                                                                         .FirstOrDefault();
                  }
            }

            public override IEnumerable<FamousPerson> FindByLinq(Func<FamousPerson, bool> expression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.FamousPersons.Include(p => p.PersonType)
                                                                         .Where(expression)
                                                                         .Select(p => p)
                                                                         .ToList();
                  }
            }

            public override IEnumerable<V> FindBySelect<V>(Func<FamousPerson, V> selectExpression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.FamousPersons.Include(p => p.PersonType)
                                                                         .Select(selectExpression)
                                                                         .ToList();
                  }
            }

            public override IEnumerable<object> FindByWhereAndSelect(Func<FamousPerson, bool> whereExpression, Func<FamousPerson, object> selectExpression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.FamousPersons.Include(p => p.PersonType)
                                                                         .Where(whereExpression)
                                                                         .Select(selectExpression)
                                                                          .ToList();
                  }
            }

            public void testTran()
            {
                  //数据库上下文
                  using (var context = new ModernHisContext())
                  {
                        //开启事务
                        using (var scope = context.Database.BeginTransaction())
                        {
                              try
                              {
                                    //添加一个famousePerson
                                    var famousePerson = new FamousPerson();
                                    context.FamousPersons.Add(famousePerson);
                                    //添加一个historyEvent
                                    var historyEvent = new HistoryEvent();
                                    context.HistoryEvents.Add(historyEvent);

                                    scope.Commit();//正常完成就可以提交，famousePerson和historyEvent都会添加
                              }
                              catch (Exception ex)
                              {
                                    scope.Rollback();//发生异常就回滚，famousePerson和historyEvent都不会添加
                              }
                        }
                  }
                  //数据库上下文
                  using (var context = new ModernHisContext())
                  {
                        //添加一个famousePerson
                        var famousePerson = new FamousPerson();
                        context.FamousPersons.Add(famousePerson);
                        //添加一个historyEvent
                        var historyEvent = new HistoryEvent();
                        context.HistoryEvents.Add(historyEvent);
                        context.SaveChanges();//savechanges方法会将对数据库的多个封装为一个完整的事务
                  }
            }
      }
}


