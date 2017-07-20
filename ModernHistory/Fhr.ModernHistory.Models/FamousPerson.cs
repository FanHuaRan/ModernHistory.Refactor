using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhr.ModernHistory.Models
{
    /// <summary>
    /// 名人信息
    /// 2017/06/30 fhr
    /// </summary>
    public class FamousPerson
    {

        /// <summary>
        /// 编号
        /// </summary>
        public Int32 FamousPersonId { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [Required(ErrorMessage = "Person Name is required")]
        [StringLength(20)]
        public string PersonName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "Gender is required")]
        public byte Gender { get; set; }

        /// <summary>
        /// 省份籍贯
        /// </summary>
        [Required(ErrorMessage = "Province is required")]
        [StringLength(20)]
        public string Province { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Required(ErrorMessage = "Nation is required")]
        [StringLength(10)]
        public string Nation { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Required(ErrorMessage = "date of birth is required")]
        public DateTime BornDate { get; set; }

        /// <summary>
        /// 出生地点
        /// </summary>
        [Required(ErrorMessage = "Born Place is required")]
        public String BornPlace { get; set; }

        /// <summary>
        /// 出生地X坐标
        /// </summary>
        [Required(ErrorMessage = "Born longitude is required")]
        public double BornX { get; set; }

        /// <summary>
        /// 出生地Y坐标
        /// </summary>
        [Required(ErrorMessage = "Born  Latitude is required")]
        public double BornY { get; set; }

        /// <summary>
        /// 逝世日期
        /// </summary>
        [Required(ErrorMessage = "date of dead is required")]
        public DateTime DeadDate { get; set; }

        /// <summary>
        /// 名人类型编号
        /// </summary>
        [Required(ErrorMessage = "FamousPersonType Id is required")]
        public Int32 FamousPersonTypeId { get; set; }

        /// <summary>
        /// 名人类型
        /// </summary>
        public virtual FamousPersonType PersonType { get; set; }
    }
}
