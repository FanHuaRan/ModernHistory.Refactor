using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Dtos.SearchModels;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// FamousPerson服务接口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IFamousPersonService
    {
            IEnumerable<FamousPersonInfo> FindAll();

            FamousPersonInfo FindById(Object id);

            void Update(FamousPersonInfo famousePerson);

            FamousPersonInfo Save(FamousPersonInfo famousePerson);

            void Delete(object id);

            IEnumerable<FamousPersonInfo> Search(PersonSearchModel searchModel);
      }
}
