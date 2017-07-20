using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;
using Fhr.ModernHistory.Models.SearchModels;
using Fhr.ModernHistory.Repositorys;
using Fhr.ModernHistory.Repositorys.Impl;

namespace Fhr.ModernHistory.Services.Impl
{
      /// <summary>
      /// FamousPerson服务实现
      /// 2017/07/02 fhr
      /// </summary>
      public class FamousPersonServiceClass : IFamousPersonService
      {
            private IFamousPersonRepository famousPersonRepository = null;

            public FamousPersonServiceClass(IFamousPersonRepository famousPersonRepository)
            {
                  this.famousPersonRepository = famousPersonRepository;
            }

            public void Delete(object id)
            {
                  famousPersonRepository.DeleteById(id);
            }

            public IEnumerable<FamousPerson> FindAll()
            {
                  return famousPersonRepository.FindAll();
            }

            public FamousPerson FindById(object id)
            {
                  return famousPersonRepository.FindById(id);
            }

            public FamousPerson Save(FamousPerson famousePerson)
            {
                  return famousPersonRepository.Save(famousePerson);
            }

            public void Update(FamousPerson famousePerson)
            {
                   famousPersonRepository.Update(famousePerson,p=>p.FamousPersonId);
            }

            public IEnumerable<FamousPerson> Search(PersonSearchModel searchModel)
            {
                  //初始化查询sql语句
                  var sqlBuilder = new StringBuilder("select * from famousperson where");
                  //初始化查询参数
                  var searchParams = new List<object>();
                  //处理参数
                  DealStringQueryParam("PersonName", searchModel.PersonName, sqlBuilder, searchParams);
                  DealStringQueryParam("Province", searchModel.Province, sqlBuilder, searchParams);
                  DealStringQueryParam("Nation", searchModel.Nation, sqlBuilder, searchParams);
                  DealStringQueryParam("BornPlace", searchModel.BornPlace, sqlBuilder, searchParams);
                  DealStringQueryParam("DeadPlace", searchModel.DeadPlace, sqlBuilder, searchParams);
                  if (searchModel.FamousPersonTypeId != null)
                  {
                        sqlBuilder.Append("FamousPersonTypeId ={0} and ");
                        searchParams.Add(searchModel.FamousPersonTypeId);
                  }
                  if (searchModel.MinBornDate != null)
                  {
                        sqlBuilder.Append("BornDate >={0} and ");
                        searchParams.Add(searchModel.MinBornDate);
                  }
                  if (searchModel.MaxBornDate != null)
                  {
                        sqlBuilder.Append("BornDate <={0} and ");
                        searchParams.Add(searchModel.MaxBornDate);
                  }
                  if (searchModel.MinDeadDate != null)
                  {
                        sqlBuilder.Append("DeadDate >={0} and ");
                        searchParams.Add(searchModel.MinDeadDate);
                  }
                  if (searchModel.MaxDeadDate != null)
                  {
                        sqlBuilder.Append("DeadDate <={0} and ");
                        searchParams.Add(searchModel.MaxDeadDate);
                  }
                  //无任何查询参数 返回无元素的数组
                  if (searchParams.Count == 0)
                  {
                        return new List<FamousPerson>();
                  }
                  //移除最后多余的"and "
                  sqlBuilder.Remove(sqlBuilder.Length - 5, 4);
                  //sql查询
                  return famousPersonRepository.FindBySQL(sqlBuilder.ToString(), searchParams.ToArray());
            }
            private void DealStringQueryParam(string paramName,string value,StringBuilder builder,List<object> searchParams)
            {
                  if (!String.IsNullOrEmpty(value))
                  {
                        builder.Append(" " + paramName + " ={0} and ");
                        searchParams.Add(value);
                  }
            }
      }
}
