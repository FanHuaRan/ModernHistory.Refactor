using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// FamousPerson服务接口
      /// 2017/07/02 fhr
      /// </summary>
      public interface IFamousPersonService
    {
            IEnumerable<FamousPerson> FindAll();

            FamousPerson FindById(Object id);

            void Update(FamousPerson famousePerson);

            FamousPerson Save(FamousPerson famousePerson);

            void Delete(object id);

            IEnumerable<FamousPerson> Search(PersonSearchModel searchModel);
      }
}
