using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
    /// <summary>
    /// 名人事件关系
    /// </summary>
    public class PersonEventRelation
    {

        /// <summary>
        /// 名人事件关系编号
        /// </summary>
        public Int32 PersonEventRelationId { get; set; }
        /// <summary>
        /// 名人编号
        /// </summary>
        [Required(ErrorMessage = "FamousPersonId is required")]
        public Int32 FamousPersonId { get; set; }
        /// <summary>
        /// 历史事件编号
        /// </summary>
        [Required(ErrorMessage = "HistoryEventId is required")]
        public Int32 HistoryEventId { get; set; }

    }
}
