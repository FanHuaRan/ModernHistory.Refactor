using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.DtoConverters;
using Fhr.ModernHistory.Dtos;
using Fhr.ModernHistory.Dtos.SearchModels;
using Fhr.ModernHistory.Models;
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

         //   private IFamousPersonTypeRepository famousTypeRepository = null;

            private IPersonTypeRelationRepository personTypeRelationRepository = null;

            public FamousPersonServiceClass(IFamousPersonRepository famousPersonRepository, IPersonTypeRelationRepository personTypeRelationRepository)
            {
                  this.famousPersonRepository = famousPersonRepository;
                //  this.famousTypeRepository = famousTypeRepository;
                  this.personTypeRelationRepository = personTypeRelationRepository;
            }

            public void Delete(object id)
            {
                  famousPersonRepository.DeleteById(id);
            }

            public IEnumerable<FamousPersonInfo> FindAll()
            {
                  var persons = famousPersonRepository.FindAll();
                  var personInfos = new List<FamousPersonInfo>();
                  foreach (var person in persons)
                  {
                       var typeIds=personTypeRelationRepository.FindByWhereAndSelect(p => p.FamousPersonId == person.FamousPersonId, p => p.FamousPersonTypeId).ToList();
                        personInfos.Add(FamousPersonConverter.ConvertToDto(person, (IEnumerable<int>)typeIds));
                  }
                  return personInfos;
            }

            public FamousPersonInfo FindById(object id)
            {
                  var person=famousPersonRepository.FindById(id);
                  var typeIds = personTypeRelationRepository.FindByWhereAndSelect(p => p.FamousPersonId == (int)id, p => p.FamousPersonTypeId);
                  return FamousPersonConverter.ConvertToDto(person, (IEnumerable<int>)typeIds);
            }

            public FamousPersonInfo Save(FamousPersonInfo famousePersonInfo)
            {
                  var person = famousPersonRepository.Save(FamousPersonConverter.ConvertToDo(famousePersonInfo));
                  var typeIds = famousePersonInfo.PersonTypeIds;
                  foreach(var typeId in typeIds)
                  {
                        personTypeRelationRepository.Save(new PersonTypeRelation()
                        {
                               FamousPersonTypeId=typeId,
                                FamousPersonId=person.FamousPersonId
                        });
                  }
                  famousePersonInfo.FamousPersonId = person.FamousPersonId;
                  return famousePersonInfo;
            }

            public void Update(FamousPersonInfo famousePersonInfo)
            {
                  famousPersonRepository.Update(FamousPersonConverter.ConvertToDo(famousePersonInfo), p => p.FamousPersonId);
                  personTypeRelationRepository.DeleteByLinq(p => p.FamousPersonId == famousePersonInfo.FamousPersonId);
                  var typeIds = famousePersonInfo.PersonTypeIds;
                  foreach (var typeId in typeIds)
                  {
                        personTypeRelationRepository.Save(new PersonTypeRelation()
                        {
                              FamousPersonTypeId = typeId,
                              FamousPersonId = famousePersonInfo.FamousPersonId
                        });
                  }
            }

            public IEnumerable<FamousPersonInfo> Search(PersonSearchModel searchModel)
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
                  var personInfos = new List<FamousPersonInfo>();
                  //无任何查询参数 返回无元素的数组
                  if (searchParams.Count == 0)
                  {
                        return personInfos;
                  }
                  //移除最后多余的"and "
                  sqlBuilder.Remove(sqlBuilder.Length - 5, 4);
                  //sql查询
                  var persons=famousPersonRepository.FindBySQL(sqlBuilder.ToString(), searchParams.ToArray());
                  foreach (var person in persons)
                  {
                        var typeIds = personTypeRelationRepository.FindByWhereAndSelect(p => p.FamousPersonId == person.FamousPersonId, p => p.FamousPersonTypeId).ToList();
                        personInfos.Add(FamousPersonConverter.ConvertToDto(person, (IEnumerable<int>)typeIds));
                  }
                  return personInfos;
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
