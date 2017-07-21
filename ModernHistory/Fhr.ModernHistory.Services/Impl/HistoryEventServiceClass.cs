using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.DtoConverters;
using Fhr.ModernHistory.DtoDoConverters;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Dtos.SearchModels;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Repositorys;
using Fhr.ModernHistory.Repositorys.Impl;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// HistoryEvent服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class HistoryEventServiceClass: IHistoryEventService
      {
            private IHistoryEventRepository historyEventRepository = null;

            private IPersonEventRelationRepository personEventRelationRepository = null;

            public HistoryEventServiceClass(IHistoryEventRepository historyEventRepository, IPersonEventRelationRepository personEventRelationRepository)
            {
                  this.historyEventRepository = historyEventRepository;
                  this.personEventRelationRepository = personEventRelationRepository;
            }

            public void Delete(object id)
            {
                  historyEventRepository.DeleteById(id);
            }

            public IEnumerable<HistoryEventInfo> FindAll()
            {
                  var events = historyEventRepository.FindAll();
                  var eventInfos = new List<HistoryEventInfo>();
                  foreach (var person in events)
                  {
                        var personIds = personEventRelationRepository.FindByWhereAndSelect(p => p.HistoryEventId == person.HistoryEventId, p => p.FamousPersonId).ToList();
                        eventInfos.Add(HistoryEventConverter.ConvertToDto(person, (IEnumerable<int>)personIds));
                  }
                  return eventInfos;
            }

            public HistoryEventInfo FindById(object id)
            {
                  var @event = historyEventRepository.FindById(id);
                  var personIds = personEventRelationRepository.FindByWhereAndSelect(p => p.HistoryEventId == @event.HistoryEventId, p => p.FamousPersonId).ToList();
                  return HistoryEventConverter.ConvertToDto(@event, (IEnumerable<int>)personIds);
            }

            public HistoryEventInfo Save(HistoryEventInfo historyEventInfo)
            {
                  var @event = historyEventRepository.Save(HistoryEventConverter.ConvertToDo(historyEventInfo));
                  var personIds = historyEventInfo.PersonIds;
                  foreach (var personId in personIds)
                  {
                        personEventRelationRepository.Save(new PersonEventRelation()
                        {
                              HistoryEventId=@event.HistoryEventId,
                              FamousPersonId = personId
                        });
                  }
                  historyEventInfo.HistoryEventId = @event.HistoryEventId;
                  return historyEventInfo;
            }

            public void Update(HistoryEventInfo historyEventInfo)
            {
                  historyEventRepository.Update(HistoryEventConverter.ConvertToDo(historyEventInfo), p => p.HistoryEventId);
                  personEventRelationRepository.DeleteByLinq(p => p.HistoryEventId==historyEventInfo.HistoryEventId);
                  var personIds = historyEventInfo.PersonIds;
                  foreach (var personId in personIds)
                  {
                        personEventRelationRepository.Save(new PersonEventRelation()
                        {
                              HistoryEventId = historyEventInfo.HistoryEventId,
                              FamousPersonId = personId
                        });
                  }
            }

            public IEnumerable<HistoryEventInfo> Search(EventSearchModel searchModel)
            {
                  //初始化查询sql语句
                  var sqlBuilder = new StringBuilder("select * from HistoryEvent where");
                  //初始化查询参数
                  var searchParams = new List<object>();
                  //处理参数
                  DealStringQueryParam("Title", searchModel.Title, sqlBuilder, searchParams);
                  DealStringQueryParam("Province", searchModel.Province, sqlBuilder, searchParams);
                  DealStringQueryParam("Place", searchModel.Place, sqlBuilder, searchParams);
                  if (searchModel.FamousPersonId != null)
                  {
                        sqlBuilder.Append("HistoryEventTypeId ={0} and ");
                     //   searchParams.Add(searchModel.HistoryEventTypeId);
                  }
                  if (searchModel.MinOccurDate != null)
                  {
                        sqlBuilder.Append("OccurDate >={0} and ");
                        searchParams.Add(searchModel.MinOccurDate);
                  }
                  if (searchModel.MaxOccurDate != null)
                  {
                        sqlBuilder.Append("OccurDate <={0} and ");
                        searchParams.Add(searchModel.MaxOccurDate);
                  }
                  var eventInfos = new List<HistoryEventInfo>();
                  //无任何查询参数 返回无元素的数组
                  if (searchParams.Count == 0)
                  {
                        return eventInfos;
                  }
                  //移除最后多余的"and "
                  sqlBuilder.Remove(sqlBuilder.Length - 5, 4);
                  //sql查询
                  var events=historyEventRepository.FindBySQL(sqlBuilder.ToString(), searchParams.ToArray());
                  foreach (var @event in events)
                  {
                        var personIds = personEventRelationRepository.FindByWhereAndSelect(p => p.HistoryEventId == @event.HistoryEventId, p => p.FamousPersonId).ToList();
                        eventInfos.Add(HistoryEventConverter.ConvertToDto(@event, (IEnumerable<int>)personIds));
                  }
                  return eventInfos;
            }
            private void DealStringQueryParam(string paramName, string value, StringBuilder builder, List<object> searchParams)
            {
                  if (!String.IsNullOrEmpty(value))
                  {
                        builder.Append(" " + paramName + " ={0} and ");
                        searchParams.Add(value);
                  }
            }

      }
}
