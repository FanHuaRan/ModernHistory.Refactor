using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Dtos.SearchModels;
using Fhr.ModernHistory.Services;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi.Controllers
{
      /// <summary>
      /// HistoryEvent api控制器
      ///  2017/07/02 fhr
      /// </summary>
     // [Authorize]
      public class HistoryEventController : ApiController
      {

            public IHistoryEventService HistoryEventService { get; set; }

            public IPictureService PictureService { get; set; }


            public HistoryEventController(IHistoryEventService historyEventService, IPictureService pictureService)
            {
                  this.HistoryEventService = historyEventService;
                  this.PictureService = pictureService;
            }

            public IEnumerable<HistoryEventInfo> Get()
            {
                  return HistoryEventService.FindAll();
            }

            public HistoryEventInfo Get(int id)
            {
                  var person = HistoryEventService.FindById(id);
                  if (person == null)
                  {
                        throw new CustomerApiException(HttpStatusCode.NotFound, 1, "该历史事件不存在");
                  }
                  return person;
            }
            [HttpPost]
            public HistoryEventInfo Save([FromBody]HistoryEventInfo value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        return HistoryEventService.Save(value);
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Update(int id, [FromBody]HistoryEventInfo value)
            {
                  if (value != null && ModelState.IsValid)
                  {
                        value.HistoryEventId = id;
                        HistoryEventService.Update(value);
                        //不处理图片文件了
                  }
                  else
                  {
                        throw new CustomerApiException(HttpStatusCode.NotAcceptable, 1, "字段值不合法");
                  }
            }
            [HttpPost]
            public void Delete(int id)
            {
                  HistoryEventService.Delete(id);
            }
            [HttpPost]
            public IEnumerable<HistoryEventInfo> Search([FromBody] EventSearchModel searchModel)
            {
                  return HistoryEventService.Search(searchModel);
            }
      }
}