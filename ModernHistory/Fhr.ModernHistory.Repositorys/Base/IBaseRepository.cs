using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Repositorys
{
    /// <summary>
    /// 实体基本泛型仓库接口
    /// 2017/07/01 fhr
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T:class
    {
        /// <summary>
        /// 根据ID进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(Object id);
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="obj"></param>
        void Delete(T obj);
        /// <summary>
        /// 通过ID删除对象
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(Object id);
        /// <summary>
        /// 新增对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Save(T obj);
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        void Update(T obj);
        /// <summary>
        /// 更新对象 同时加一个获取对象主键的委托
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="getPkHandler"></param>
        /// <returns></returns>
        void Update(T obj, Func<T, object> getPkHandler);
        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// 通过LINQ进行查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> FindByLinq(Func<T, bool> expression);
        /// <summary>
        /// 查询并选择
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <param name="selectExpression"></param>
        /// <returns></returns>
        IEnumerable<V>  FindByWhereAndSelect<V>(Func<T, bool> whereExpression, Func<T, V> selectExpression);
        /// <summary>
        /// 选择
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="selectExpression"></param>
        /// <returns></returns>
        IEnumerable<V> FindBySelect<V>(Func<T, V> selectExpression);
        /// <summary>
        /// 通过sql进行查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        IEnumerable<T> FindBySQL(string sql, params object[] sqlParams);

            /// <summary>
            /// 通过sql进行查询
            /// </summary>
            /// <param name="sql"></param>
            /// <param name="sqlParams"></param>
            /// <returns></returns>
            void DeleteByLinq(Func<T, bool> whereExpression);
      }
}
