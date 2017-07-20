using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
      /// <summary>
      /// 名人类型关系
      /// 2017/07/20 fhr
      /// </summary>
      public class PersonTypeRelation
      {
            public Int32 PersonTypeRelationId { get; set; }
            public Int32 FamousPersonId { get; set; }
            public Int32 FamousPersonTypeId { get; set; }
      }
}
