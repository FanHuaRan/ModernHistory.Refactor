using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys;
using Fhr.ModernHistory.Repositorys.Impl;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// FamousPersonType服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class FamousPersonTypeServiceClass : IFamousPersonTypeService
      {
            private IFamousPersonTypeRepository famousPersonRepository = null;

            public FamousPersonTypeServiceClass(IFamousPersonTypeRepository famousPersonRepository)
            {
                  this.famousPersonRepository = famousPersonRepository;
            }

            public void Delete(object id)
            {
                  famousPersonRepository.DeleteById(id);
            }

            public IEnumerable<FamousPersonType> FindAll()
            {
                  return famousPersonRepository.FindAll();
            }

            public FamousPersonType FindById(object id)
            {
                  return famousPersonRepository.FindById(id);
            }

            public FamousPersonType FindByName(string name)
            {
                 return famousPersonRepository.FindByLinq(p => p.FamousPersonTypeName == name)
                                                          .FirstOrDefault();
            }

            public FamousPersonType Save(FamousPersonType famousePersonType)
            {
                  return famousPersonRepository.Save(famousePersonType);
            }

            public void Update(FamousPersonType famousePersonType)
            {
                  famousPersonRepository.Update(famousePersonType);
            }
      }
}
