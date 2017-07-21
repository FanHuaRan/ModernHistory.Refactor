using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.DtoDoConverters;
using Fhr.ModernHistory.Dtos;
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
            private IFamousPersonTypeRepository famousPersonTypeRepository = null;

            public FamousPersonTypeServiceClass(IFamousPersonTypeRepository famousPersonRepository)
            {
                  this.famousPersonTypeRepository = famousPersonRepository;
            }

            public void Delete(object id)
            {
                  famousPersonTypeRepository.DeleteById(id);
            }

            public IEnumerable<FamousPersonTypeInfo> FindAll()
            {
                  var types=famousPersonTypeRepository.FindAll();
                  var typeInfos = new List<FamousPersonTypeInfo>();
                  foreach(var type in types)
                  {
                        typeInfos.Add(FamousPersonTypeConverter.ConvertToDto(type));
                  }
                  return typeInfos;
            }

            public FamousPersonTypeInfo FindById(object id)
            {
               return FamousPersonTypeConverter.ConvertToDto(famousPersonTypeRepository.FindById(id));
            }

            public FamousPersonTypeInfo FindByName(string name)
            {
                  return FamousPersonTypeConverter.ConvertToDto(famousPersonTypeRepository
                                                           .FindByLinq(p => p.FamousPersonTypeName == name)
                                                           .FirstOrDefault());
            }

            public FamousPersonTypeInfo Save(FamousPersonTypeInfo famousePersonTypeInfo)
            {
                  var type=famousPersonTypeRepository.Save(FamousPersonTypeConverter.ConvertToDo(famousePersonTypeInfo));
                  famousePersonTypeInfo.FamousPersonTypeId = type.FamousPersonTypeId;
                  return famousePersonTypeInfo;
            }

            public void Update(FamousPersonTypeInfo famousePersonTypeInfo)
            {
                  famousPersonTypeRepository.Update(FamousPersonTypeConverter.ConvertToDo(famousePersonTypeInfo));
            }
      }
}
