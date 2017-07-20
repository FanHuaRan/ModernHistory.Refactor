using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    /// <summary>
    /// 名人查询参数模型
    /// 2017/07/06 fhr
    /// </summary>
    public class PersonSearchModel : ModelBase<PersonSearchModel>
    {
        private string personName;

        private string province;

        private string nation;

        private string bornPlace;

        private string deadPlace;

        private DateTime? minBornDate;

        private DateTime? maxBornDate;

        private DateTime? minDeadDate;

        private DateTime? maxDeadDate;

        private Int32? famousPersonTypeId;



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

        public string BornPlace
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

        public string DeadPlace
        {
            get { return deadPlace; }

            set
            {
                if (deadPlace != value)
                {
                    deadPlace = value;
                    NotifyPropertyChanged(p => p.DeadPlace);
                }
            }
        }

        public DateTime? MinBornDate
        {
            get { return minBornDate; }

            set
            {
                if (minBornDate != value)
                {
                    minBornDate = value;
                    NotifyPropertyChanged(p => p.MinBornDate);
                }
            }
        }

        public DateTime? MaxBornDate
        {
            get { return maxBornDate; }

            set
            {
                if (maxBornDate != value)
                {
                    maxBornDate = value;
                    NotifyPropertyChanged(p => p.MaxBornDate);
                }
            }
        }

        public DateTime? MinDeadDate
        {
            get { return minDeadDate; }

            set
            {
                if (minDeadDate != value)
                {
                    minDeadDate = value;
                    NotifyPropertyChanged(p => p.MinDeadDate);
                }
            }
        }

        public DateTime? MaxDeadDate
        {
            get { return maxDeadDate; }

            set
            {
                if (maxDeadDate != value)
                {
                    maxDeadDate = value;
                    NotifyPropertyChanged(p => p.MaxDeadDate);
                }
            }
        }

        public Int32? FamousPersonTypeId
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
    }
}
