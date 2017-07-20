using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys;

namespace Fhr.ModernHistory.Services.Impl
{
      public class PersonEventRelationServiceClass : IPersonEventRelationService
      {
            private IPersonEventRelationRepository personEventRelationRepository = null;

            public PersonEventRelationServiceClass(IPersonEventRelationRepository personEventRelationRepository)
            {
                  this.personEventRelationRepository = personEventRelationRepository;
            }

            public void Delete(object id)
            {
                  personEventRelationRepository.DeleteById(id);            }

            public IEnumerable<PersonEventRelation> FindAll()
            {
                 return personEventRelationRepository.FindAll();
                        }

            public PersonEventRelation FindById(object id)
            {
                  return personEventRelationRepository.FindById(id);
            }

            public IEnumerable<PersonEventRelation> FindByPersonAndEvent(int? personId, int? eventId)
            {
                  if (personId == null && eventId == null)
                  {
                        return new List<PersonEventRelation>();
                  }
                  if (personId == null)
                  {
                        return personEventRelationRepository.FindByLinq(p => p.HistoryEventId==eventId);
                  }
                  if (eventId == null)
                  {
                        return personEventRelationRepository.FindByLinq(p => p.FamousPersonId == personId);
                  }
                  return personEventRelationRepository.FindByLinq(p => p.FamousPersonId == personId && p.HistoryEventId == eventId);
            }

            public PersonEventRelation Save(PersonEventRelation personEventRelation)
            {
                 return personEventRelationRepository.Save(personEventRelation);
            }

            public void Update(PersonEventRelation personEventRelation)
            {
                  personEventRelationRepository.Update(personEventRelation);            }
      }
}
