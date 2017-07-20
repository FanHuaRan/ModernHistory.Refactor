using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Models
{
    public class PersonEventRelationSearchModel : ModelBase<PersonEventRelationSearchModel>
    {
        private Int32? personId;

        private Int32? eventId;
        public Int32? PersonId
        {
            get { return personId; }

            set
            {
                if (personId != value)
                {
                    personId = value;
                    NotifyPropertyChanged(p => p.PersonId);
                }
            }
        }

        public Int32? EventId
        {
            get { return eventId; }

            set
            {
                if (eventId != value)
                {
                    eventId = value;
                    NotifyPropertyChanged(p => p.EventId);
                }
            }
        }
    }
}
