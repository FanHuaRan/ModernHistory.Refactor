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
    /// 名人事件关系
    /// </summary>
    public class PersonEventRelation : ModelBase<PersonEventRelation>
    {
        private Int32 personEventRelationId;
        private Int32 famousPersonId;
        private Int32 historyEventId;

        /// <summary>
        /// 名人事件关系编号
        /// </summary>
        public Int32 PersonEventRelationId
        {
            get { return personEventRelationId; }

            set
            {
                if (personEventRelationId != value)
                {
                    personEventRelationId = value;
                    NotifyPropertyChanged(p => p.PersonEventRelationId);
                }
            }
        }
        /// <summary>
        /// 名人编号
        /// </summary>
        [Required(ErrorMessage = "FamousPersonId is required")]
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
        /// 历史事件编号
        /// </summary>
        [Required(ErrorMessage = "HistoryEventId is required")]
        public Int32 HistoryEventId
        {
            get { return historyEventId; }

            set
            {
                if (historyEventId != value)
                {
                    historyEventId = value;
                    NotifyPropertyChanged(p => p.HistoryEventId);
                }
            }
        }

    }
}
