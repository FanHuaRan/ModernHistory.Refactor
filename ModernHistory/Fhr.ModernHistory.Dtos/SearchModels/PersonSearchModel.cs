using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Dtos.SearchModels
{
      /// <summary>
      /// 名人查询参数模型
      /// 2017/07/06 fhr
      /// </summary>
      public class PersonSearchModel
      {
            public string PersonName { get; set; }

            public string Province { get; set; }

            public string Nation { get; set; }

            public string BornPlace { get; set; }

            public string DeadPlace { get; set; }

            public DateTime? MinBornDate { get; set; }

            public DateTime? MaxBornDate { get; set; }

            public DateTime? MinDeadDate { get; set; }

            public DateTime? MaxDeadDate { get; set; }

            public Int32? FamousPersonTypeId { get; set; }

      }
}
