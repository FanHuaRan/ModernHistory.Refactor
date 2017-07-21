using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// HistoryEvent服务接口
      /// 2017/07/02 fhr
      /// </summary>
     public  interface IFamousPersonTypeService
      {
            IEnumerable<FamousPersonTypeInfo> FindAll();

            FamousPersonTypeInfo FindById(Object id);

            void Update(FamousPersonTypeInfo famousePersonTypeInfo);

            FamousPersonTypeInfo Save(FamousPersonTypeInfo famousePersonTypeInfo);

            void Delete(object id);

            FamousPersonTypeInfo FindByName(string name);
      }
}
