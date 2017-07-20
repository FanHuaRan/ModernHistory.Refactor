using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// HistoryEvent服务接口
      /// 2017/07/02 fhr
      /// </summary>
     public  interface IFamousPersonTypeService
      {
            IEnumerable<FamousPersonType> FindAll();

            FamousPersonType FindById(Object id);

            void Update(FamousPersonType famousePersonType);

            FamousPersonType Save(FamousPersonType famousePersonType);

            void Delete(object id);

            FamousPersonType FindByName(string name);
      }
}
