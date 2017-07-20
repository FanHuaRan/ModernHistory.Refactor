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
      /// HistoryEventType API控制器
      /// 2017/07/06 fhr
      /// </summary>
     // [Authorize]
      public class HistoryEventTypeController : ApiController
      {

            public IHistoryEventTypeService HistoryEventTypeService { get; set; }

            public HistoryEventTypeController(IHistoryEventTypeService historyEventTypeService)
            {
                  this.HistoryEventTypeService = historyEventTypeService;
            }

            public IEnumerable<HistoryEventType> Get()
            {
                  return HistoryEventTypeService.FindAll();
            }
            public HistoryEventType Get(int id)
            {
                  var person = HistoryEventTypeService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "该历史事件类型不存在");
                  }
                  return person;
            }
            [HttpPost]
            public HistoryEventType Save([FromBody]HistoryEventType value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                      return   HistoryEventTypeService.Save(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Update(int id, [FromBody]HistoryEventType value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        value.HistoryEventTypeId = id;
                        HistoryEventTypeService.Update(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Delete(int id)
            {
                  HistoryEventTypeService.Delete(id);
            }
      }
}