using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;
using Fhr.ModernHistory.Services;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// PersonEventRelation API控制器
      /// 2017/07/06 
      /// </summary>
     // [Authorize]
      public class PersonEventRelationController : ApiController
      {

            public IPersonEventRelationService PersonEventRelationService { get; set; }

            public PersonEventRelationController(IPersonEventRelationService personEventRelationService)
            {
                  this.PersonEventRelationService = personEventRelationService;
            }

            public IEnumerable<PersonEventRelation> Get()
            {
                  return PersonEventRelationService.FindAll();
            }

            public PersonEventRelation Get(int id)
            {
                  var person = PersonEventRelationService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "该关系不存在");
                  }
                  return person;
            }
            [HttpPost]
            public PersonEventRelation Save([FromBody]PersonEventRelation value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        return PersonEventRelationService.Save(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Update(int id, [FromBody]PersonEventRelation value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        value.FamousPersonId = id;
                        PersonEventRelationService.Update(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Delete(int id)
            {
                  PersonEventRelationService.Delete(id);
            }
            [HttpPost]
            public IEnumerable<PersonEventRelation> Search([FromBody] PersonEventRelationSearchModel searchModel)
            {
                  return PersonEventRelationService.FindByPersonAndEvent(searchModel.PersonId,searchModel.EventId);
            }
      }
}