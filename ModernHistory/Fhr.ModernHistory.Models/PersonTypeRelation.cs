using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

            [Required(ErrorMessage = "Famous Person Id is required")]
            public Int32 FamousPersonId { get; set; }

            [Required(ErrorMessage = "Famous Person Type Id is required")]
            public Int32 FamousPersonTypeId { get; set; }
      }
}
