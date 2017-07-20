using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 名人信息
    /// 2017/06/30 fhr
    /// </summary>
    public class FamousPerson : ModelBase<FamousPerson>
    {
        private Int32 famousPersonId;
        private string personName;
        private byte gender;
        private string province;
        private string nation;
        private DateTime bornDate;
        private String bornPlace;
        private double bornX;
        private double bornY;
        private DateTime deadDate;
        private Int32 famousPersonTypeId;
        private FamousPersonType personType;

        /// <summary>
        /// 编号
        /// </summary>
        public Int32 FamousPersonId
        {
            get { return famousPersonId; }

            set
            {
                if (famousPersonId != value)
                {
                    famousPersonId = value;
                    NotifyPropertyChanged(p => p.FamousPersonId);
                }
            }
        }

        /// <summary>
        /// 名字
        /// </summary>
        [Required(ErrorMessage = "Person Name is required")]
        [StringLength(20)]
        public string PersonName
        {
            get { return personName; }
            set
            {
                if (personName != value)
                {
                    personName = value;
                    NotifyPropertyChanged(p => p.PersonName);
                }
            }
        }

        /// <summary>
        /// 性别
        /// </summary>
        [Required(ErrorMessage = "Gender is required")]
        public byte Gender
        {
            get { return gender; }
            set
            {
                if (gender != value)
                {
                    gender = value;
                    NotifyPropertyChanged(p => p.Gender);
                }
            }
        }

        /// <summary>
        /// 省份籍贯
        /// </summary>
        [Required(ErrorMessage = "Province is required")]
        [StringLength(20)]
        public string Province
        {
            get { return province; }
            set
            {
                if (province != value)
                {
                    province = value;
                    NotifyPropertyChanged(p => p.Province);
                }
            }
        }

        /// <summary>
        /// 民族
        /// </summary>
        [Required(ErrorMessage = "Nation is required")]
        [StringLength(10)]
        public string Nation
        {
            get { return nation; }
            set
            {
                if (nation != value)
                {
                    nation = value;
                    NotifyPropertyChanged(p => p.Nation);
                }
            }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Required(ErrorMessage = "date of birth is required")]
        public DateTime BornDate
        {
            get { return bornDate; }
            set
            {
                if (bornDate != value)
                {
                    bornDate = value;
                    NotifyPropertyChanged(p => p.BornDate);
                }
            }
        }

        /// <summary>
        /// 出生地点
        /// </summary>
        [Required(ErrorMessage = "Born Place is required")]
        public String BornPlace
        {
            get { return bornPlace; }
            set
            {
                if (bornPlace != value)
                {
                    bornPlace = value;
                    NotifyPropertyChanged(p => p.BornPlace);
                }
            }
        }

        /// <summary>
        /// 出生地X坐标
        /// </summary>
        [Required(ErrorMessage = "Born longitude is required")]
        public double BornX
        {
            get { return bornX; }
            set
            {
                if (bornX != value)
                {
                    bornX = value;
                    NotifyPropertyChanged(p => p.BornX);
                }
            }
        }

        /// <summary>
        /// 出生地Y坐标
        /// </summary>
        [Required(ErrorMessage = "Born  Latitude is required")]
        public double BornY
        {
            get { return bornY; }
            set
            {
                if (bornY != value)
                {
                    bornY = value;
                    NotifyPropertyChanged(p => p.BornY);
                }
            }
        }

        /// <summary>
        /// 逝世日期
        /// </summary>
        [Required(ErrorMessage = "date of dead is required")]
        public DateTime DeadDate
        {
            get { return deadDate; }
            set
            {
                if (deadDate != value)
                {
                    deadDate = value;
                    NotifyPropertyChanged(p => p.DeadDate);
                }
            }
        }

        /// <summary>
        /// 名人类型编号
        /// </summary>
        [Required(ErrorMessage = "FamousPersonType Id is required")]
        public Int32 FamousPersonTypeId
        {
            get { return famousPersonTypeId; }
            set
            {
                if (famousPersonTypeId != value)
                {
                    famousPersonTypeId = value;
                    NotifyPropertyChanged(p => p.FamousPersonTypeId);
                }
            }
        }

        /// <summary>
        /// 名人类型
        /// </summary>
        public virtual FamousPersonType PersonType
        {
            get { return personType; }
            set
            {
                if (personType != value)
                {
                    personType = value;
                    NotifyPropertyChanged(p => p.PersonType);
                }
            }
        }
    }
}
