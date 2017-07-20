using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Repositorys.Contexts
{
      /// <summary>
      /// EF数据库初始化策略
      /// 2017/06/30 fhr
      /// </summary>
      public class SampleData : DropCreateDatabaseIfModelChanges<ModernHisContext>
      {
            /// <summary>
            /// 数据库初始化操作
            /// </summary>
            /// <param name="context"></param>
            protected override void Seed(ModernHisContext context)
            {
                //成都各省市经纬度：http://www.d1xz.net/xp/jingwei/sicuan.aspx
                  var personTypes = new List<FamousPersonType>()
                  {
                        new FamousPersonType(){FamousPersonTypeName =" 政治家"},
                        new FamousPersonType(){FamousPersonTypeName = "思想家"},
                        new FamousPersonType(){FamousPersonTypeName = "军事家"},
                        new FamousPersonType(){FamousPersonTypeName = "文学家"},
                        new FamousPersonType(){FamousPersonTypeName = "商人"},
                        new FamousPersonType(){FamousPersonTypeName = "明星"},
                        new FamousPersonType(){FamousPersonTypeName = "其它"},
                  };
                  personTypes.ForEach(p => context.FamousPersonTypes.Add(p));
                  var persons = new List<FamousPerson>()
                  {
                        new FamousPerson()
                        {
                              PersonName="曾国藩",
                              Province="湖南",
                              Nation="汉族",
                              BornDate=DateTime.Parse("1828/06/02"),
                              BornPlace="湖南省xxx村",
                              BornX=54521d,
                              BornY=124d,
                              DeadDate=DateTime.Parse("1908/06/02"),
                              Gender=1,
                            //  PersonType=personTypes.First()
                        },
                           new FamousPerson()
                        {
                              PersonName="邓小平",
                              Province="四川",
                              Nation="汉族",
                              BornDate=DateTime.Parse("1900/06/02"),
                              BornPlace="湖南省xxx村",
                              BornX=54521d,
                              BornY=124d,
                              DeadDate=DateTime.Parse("1998/06/02"),
                              Gender=1,
                             // PersonType=personTypes.First()
                        }
                  };
                  var events = new List<HistoryEvent>() {
                        new HistoryEvent()
                        {
                               Detail="xxxx事件",
                               OccurDate=DateTime.Now,
                                OccurX=45d,
                                   OccurY=45d,
                                    Place="XX地方",
                                     Province="四川",
                                      Title="事件标题哈",
                        }
                  };
                  personTypes.ForEach(p => context.FamousPersonTypes.Add(p));
                  persons.ForEach(p => context.FamousPersons.Add(p));
                  events.ForEach(p => context.HistoryEvents.Add(p));
                  context.SaveChanges();
            }
      }
}
