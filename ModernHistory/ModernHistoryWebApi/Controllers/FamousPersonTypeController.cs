using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Services;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// FamousPersonType API控制器
      ///  2017/07/02 fhr
      /// </summary>
     // [Authorize]
      public class FamousPersonTypeController : ApiController
      {

            public IFamousPersonTypeService FamousPersonTypeService { get; set; }

            public FamousPersonTypeController(IFamousPersonTypeService famousPersonTypeService)
            {
                  this.FamousPersonTypeService = famousPersonTypeService;
            }

            public IEnumerable<FamousPersonType> Get()
            {
                  return FamousPersonTypeService.FindAll();
            }
            public FamousPersonType Get(int id)
            {
                  var person = FamousPersonTypeService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "该名人类型不存在");
                  }
                  return person;
            }
            [HttpPost]
            public FamousPersonType Save([FromBody]FamousPersonType value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        return FamousPersonTypeService.Save(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Update(int id, [FromBody]FamousPersonType value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        value.FamousPersonTypeId = id;
                        FamousPersonTypeService.Update(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Delete(int id)
            {
                  FamousPersonTypeService.Delete(id);
            }
      }
}