using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.DtoDoConverters
{
      /// <summary>
      /// 名人类型转换器
      /// 2017/07/21 fhr
      /// </summary>
      public class FamousPersonTypeConverter
      {
            public static FamousPersonTypeInfo ConvertToDto(FamousPersonType famousPersonType)
            {
                  if (famousPersonType == null)
                  {
                        return null;
                  }
                  var typeInfo = new FamousPersonTypeInfo()
                  { 
                     FamousPersonTypeId= famousPersonType.FamousPersonTypeId,
                     FamousPersonTypeName= famousPersonType.FamousPersonTypeName
                  };
                  return typeInfo;
            }

            public static FamousPersonType ConvertToDo(FamousPersonTypeInfo famousPersonInfo)
            {
                  if (famousPersonInfo == null)
                  {
                        return null;
                  }
                  var type = new FamousPersonType()
                  {
                        FamousPersonTypeId = famousPersonInfo.FamousPersonTypeId,
                        FamousPersonTypeName = famousPersonInfo.FamousPersonTypeName
                  };
                  return type;
            }
      }
}
