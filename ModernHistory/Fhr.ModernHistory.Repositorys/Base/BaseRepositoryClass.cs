using Fhr.ModernHistory.Repositorys.Contexts;
using Fhr.ModernHistory.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Repositorys
{
      /// <summary>
      /// 泛型基本仓库实现
      /// 2017/07/01 fhr
      /// </summary>
      /// <typeparam name="T"></typeparam>
      public class BaseRepositoryClass<T> : IBaseRepository<T> where T : class
      {

            public virtual T FindById(object id)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.Set<T>().Find(id);
                  }
            }

            public void Delete(T obj)
            {
                  using (var context = new ModernHisContext())
                  {
                        context.Set<T>().Remove(obj);
                        context.SaveChanges();
                  }
            }

            public void DeleteById(object id)
            {
                  using (var context = new ModernHisContext())
                  {
                        var obj = context.Set<T>().Find(id);
                        if (obj != null)
                        {
                              context.Set<T>().Remove(obj);
                              context.SaveChanges();
                        }
                  }
            }

            public T Save(T obj)
            {
                  using (var context = new ModernHisContext())
                  {
                        context.Set<T>().Add(obj);
                        context.SaveChanges();
                        return obj;
                  }
            }

            public virtual void Update(T obj)
            {
                  throw new NotImplementedException();
            }
            /// <summary>
            /// EF的更新最好的办法就是先查询再修改，不然很麻烦
            /// </summary>
            /// <param name="obj"></param>
            /// <param name="getPkHandler"></param>
            public void Update(T obj, Func<T, object> getPkHandler)
            {
                  using (var context = new ModernHisContext())
                  {
                        var key = getPkHandler.Invoke(obj);
                        var oldObj = context.Set<T>().Find(key);
                        if (oldObj != null)
                        {
                              ObjectRefletUtil.SetValue<T>(oldObj, obj);
                              context.Entry<T>(oldObj).State = EntityState.Modified;
                              context.SaveChanges();
                        }
                  }
            }

            public virtual IEnumerable<T> FindAll()
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.Set<T>()
                                      .Select(p => p)
                                      .ToList();
                  }
            }

            public virtual IEnumerable<T> FindByLinq(Func<T, bool> expression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.Set<T>()
                                      .Where(expression)
                                      .Select(p => p)
                                      .ToList();
                  }
            }

            public virtual IEnumerable<object> FindByWhereAndSelect(Func<T, bool> whereExpression, Func<T, object> selectExpression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.Set<T>()
                                      .Where(whereExpression)
                                      .Select(selectExpression)
                                      .ToList();
                  }
            }

            public virtual IEnumerable<V> FindBySelect<V>(Func<T, V> selectExpression)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.Set<T>()
                                      .Select(selectExpression)
                                      .ToList();
                  }
            }

            public IEnumerable<T> FindBySQL(string sql, params object[] sqlParams)
            {
                  using (var context = new ModernHisContext())
                  {
                        return context.Database.SqlQuery<T>(sql, sqlParams).ToList();
                  }
            }
      }
}
