using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 名人类型
    /// 2017/06/30 fhr
    /// </summary>
    public class FamousPersonType : ModelBase<FamousPersonType>
    {
        private Int32 famousPersonTypeId;
        private String famousPersonTypeName;

        /// <summary>
        /// 名人类型编号
        /// </summary>
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
        /// 名人类型名称
        /// </summary>
        [Required(ErrorMessage = "FamousPersonType Name is required")]
        public String FamousPersonTypeName
        {
            get { return famousPersonTypeName; }
            set
            {
                if (famousPersonTypeName != value)
                {
                    famousPersonTypeName = value;
                    NotifyPropertyChanged(p => p.FamousPersonTypeName);
                }
            }
        }
    }
}
