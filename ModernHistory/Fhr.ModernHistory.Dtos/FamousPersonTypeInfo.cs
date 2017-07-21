using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Dtos
{
    /// <summary>
    /// 名人类型 
    /// 2017/06/30 fhr
    /// </summary>
    public class FamousPersonTypeInfo
    {
        /// <summary>
        /// 名人类型编号
        /// </summary>
        public Int32 FamousPersonTypeId { get; set; }

        /// <summary>
        /// 名人类型名称
        /// </summary>
        [Required(ErrorMessage = "FamousPersonType Name is required")]
        public String FamousPersonTypeName { get; set; }
    }
}
