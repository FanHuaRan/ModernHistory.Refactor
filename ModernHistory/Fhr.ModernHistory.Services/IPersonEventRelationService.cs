using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Services
{
      /// <summary>
      /// personEventRelation服务接口
      /// 2017/07/06 fhr
      /// </summary>
      public interface IPersonEventRelationService
      {
            IEnumerable<PersonEventRelation> FindAll();

            PersonEventRelation FindById(Object id);

            void Update(PersonEventRelation personEventRelation);

            PersonEventRelation Save(PersonEventRelation personEventRelation);

            void Delete(object id);

            IEnumerable<PersonEventRelation> FindByPersonAndEvent(Int32? personId,Int32?eventId);

      }
}
