using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Dtos.SearchModels;
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

            public HistoryEventServiceClass(IHistoryEventRepository historyEventRepository)
            {
                  this.historyEventRepository = historyEventRepository;
            }

            public void Delete(object id)
            {
                  historyEventRepository.DeleteById(id);
            }

            public IEnumerable<HistoryEvent> FindAll()
            {
                  return historyEventRepository.FindAll();
            }

            public HistoryEvent FindById(object id)
            {
                  return historyEventRepository.FindById(id);
            }

            public HistoryEvent Save(HistoryEvent historyEvent)
            {
                  return historyEventRepository.Save(historyEvent);
            }

            public void Update(HistoryEvent HistoryEvent)
            {
                  historyEventRepository.Update(HistoryEvent,p=>p.HistoryEventId);
            }

            public IEnumerable<HistoryEvent> Search(EventSearchModel searchModel)
            {
                  //初始化查询sql语句
                  var sqlBuilder = new StringBuilder("select * from HistoryEvent where");
                  //初始化查询参数
                  var searchParams = new List<object>();
                  //处理参数
                  DealStringQueryParam("Title", searchModel.Title, sqlBuilder, searchParams);
                  DealStringQueryParam("Province", searchModel.Province, sqlBuilder, searchParams);
                  DealStringQueryParam("Place", searchModel.Place, sqlBuilder, searchParams);
                  if (searchModel.HistoryEventTypeId != null)
                  {
                        sqlBuilder.Append("HistoryEventTypeId ={0} and ");
                        searchParams.Add(searchModel.HistoryEventTypeId);
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
                  //无任何查询参数 返回无元素的数组
                  if (searchParams.Count == 0)
                  {
                        return new List<HistoryEvent>();
                  }
                  //移除最后多余的"and "
                  sqlBuilder.Remove(sqlBuilder.Length - 5, 4);
                  //sql查询
                  return historyEventRepository.FindBySQL(sqlBuilder.ToString(), searchParams.ToArray());
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
