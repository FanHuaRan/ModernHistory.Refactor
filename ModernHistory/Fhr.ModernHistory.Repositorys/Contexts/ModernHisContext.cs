using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhr.ModernHistory.Models;

namespace Fhr.ModernHistory.Repositorys.Contexts
{
      /// <summary>
      /// EF数据上下文(mysql数据库)
      /// 2017/06/30 fhr
      /// </summary>
      [DbConfigurationType(typeof(MySqlEFConfiguration))]
      public class ModernHisContext : DbContext
      {
            public ModernHisContext()
                : base("modernhistory")
            {
                  //取消延迟加载 主要是由于每次的上下文都被释放了，对象字段就会一直为null
                  //这个木得办法，不用延迟加载了
                  this.Configuration.ProxyCreationEnabled = false;
            }

            public DbSet<FamousPerson> FamousPersons { get; set; }

            public DbSet<FamousPersonType> FamousPersonTypes { get; set; }

            public DbSet<HistoryEvent> HistoryEvents { get; set; }

            public DbSet<MhUser> MhUsers { get; set; }

            public DbSet<PersonEventRelation> PersonEventRelation { get; set; }

            public DbSet<PersonTypeRelation> PersonTypeRelations { get; set; }

            //去掉表名复数
            protected override void OnModelCreating(DbModelBuilder modelbuilder)
            {
                  modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
      }
}
