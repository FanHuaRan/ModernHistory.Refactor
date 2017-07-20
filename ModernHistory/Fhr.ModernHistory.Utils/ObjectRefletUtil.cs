using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Utils
{
    /// <summary>
    /// 反射辅助类
    /// 2017/07/01 fhr
    /// </summary>
    public class ObjectRefletUtil
    {

        /// <summary>
        /// 反射处理 赋值
        /// </summary>
        /// <param name="newObj"></param>
        /// <param name="srcObj"></param>
        public static void SetValue<T>(T newObj, T srcObj)
        {
            var t1s = srcObj.GetType().GetProperties();
            var t2s = newObj.GetType().GetProperties();
            foreach (var p in t1s)
            {
                foreach (var q in t2s)
                {
                    if (q.Name == p.Name)
                    {// 这里有可能需要对属性的类型和值做一些判断和转换，
                        //大家自己根据自己的业务添加处理，估计不会很多  
                        q.SetValue(newObj, p.GetValue(srcObj), null);
                    }
                }
            }
        }
    }
}
