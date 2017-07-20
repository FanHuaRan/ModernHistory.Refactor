using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.DtoConverters
{
      /// <summary>
      /// 名人信息转换器
      /// 201/0/20
      /// </summary>
      public class FamousPersonConverter
      {
            public static FamousPersonInfo ConvertToDto(FamousPerson famousPerson,IEnumerable<Int32> typeIds)
            {
                  var personInfo = new FamousPersonInfo()
                  {
                        BornDate = famousPerson.BornDate,
                        BornPlace = famousPerson.BornPlace,
                        BornX = famousPerson.BornX,
                        BornY = famousPerson.BornY,
                        DeadDate = famousPerson.DeadDate,
                        FamousPersonId = famousPerson.FamousPersonId,
                        Province = famousPerson.Province,
                        Gender = famousPerson.Gender,
                        Nation = famousPerson.Nation,
                        PersonName = famousPerson.PersonName,
                        PersonTypeIds=typeIds
                  };
                  return personInfo;
            }

            public static FamousPerson ConvertToDo(FamousPersonInfo famousPerson)
            {
                  var person= new FamousPerson()
                  {
                        BornDate = famousPerson.BornDate,
                        BornPlace = famousPerson.BornPlace,
                        BornX = famousPerson.BornX,
                        BornY = famousPerson.BornY,
                        DeadDate = famousPerson.DeadDate,
                        FamousPersonId = famousPerson.FamousPersonId,
                        Province = famousPerson.Province,
                        Gender = famousPerson.Gender,
                        Nation = famousPerson.Nation,
                        PersonName = famousPerson.PersonName,
                  };
                  return person;
            }
      }
}
