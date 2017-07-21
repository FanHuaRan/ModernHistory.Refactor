using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using System.Diagnostics.Contracts;
using Fhr.ModernHistory.Services;
using Fhr.ModernHistory.Services.Impl;
using Fhr.ModernHistory.Repositorys;
using Fhr.ModernHistory.Repositorys.Impl;

namespace ModernHistoryWebApi.Dependencys
{
      /// <summary>
      /// 基于Ninject的依赖注入容器，实现IDependencyResolver（IDependencyResolver继承自IDependencyScope）
      /// 前者接口代表依赖注入容器，后者代表依赖注入范围
      /// 2017/07/02 fhr
      /// </summary>
      public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
      {
            /// <summary>
            /// Ninject依赖注入内核  实际上是个容器
            /// </summary>
            private IKernel kernel;
            /// <summary>
            /// 构造方法中注入了IKernel 非必需
            /// </summary>
            /// <param name="kernel"></param>
            public NinjectDependencyResolver(IKernel kernel)
                : base(kernel)
            {
                  if (kernel == null)
                  {
                        throw new ArgumentNullException("kernel");
                  }
                  this.kernel = kernel;
                  this.AddBindings();
            }
            /// <summary>
            /// 开始作用域 
            /// </summary>
            /// <returns></returns>
            public IDependencyScope BeginScope()
            {
                  return new NinjectDependencyScope(kernel);
            }
            /// <summary>
            /// 为容器添加组件
            /// </summary>
            private void AddBindings()
            {
                  //所有组件全是单例模式 因为不存在线程问题
                  //repository层组件
                  this.kernel.Bind<IFamousPersonRepository>().To<FamousPersonRepositoryClass>().InSingletonScope();
                  this.kernel.Bind<IFamousPersonTypeRepository>().To<FamousPersonTypeRepositoryClass>().InSingletonScope();
                  this.kernel.Bind<IPersonTypeRelationRepository>().To<PersonTypeRelationRepositoryClass>().InSingletonScope();
                  this.kernel.Bind<IHistoryEventRepository>().To<HistoryEventRepositoryClass>().InSingletonScope();
                  this.kernel.Bind<IMhUserRepository>().To<MhUserRepositoryClass>().InSingletonScope();
                  this.kernel.Bind<IPersonEventRelationRepository>().To<PersonEventRelationRepositoryClass>().InSingletonScope();
                  //service层组件
                  this.kernel.Bind<IFamousPersonService>().To<FamousPersonServiceClass>().InSingletonScope();
                  this.kernel.Bind<IFamousPersonTypeService>().To<FamousPersonTypeServiceClass>().InSingletonScope();
                  this.kernel.Bind<IHistoryEventService>().To<HistoryEventServiceClass>().InSingletonScope();
                  this.kernel.Bind<IMhUserService>().To<MhUserServiceClass>().InSingletonScope();
                //  this.kernel.Bind<IPersonEventRelationService>().To<PersonEventRelationServiceClass>().InSingletonScope();
                  this.kernel.Bind<IPictureService>().To<PictureServiceClass>().InSingletonScope();
            }
      }
      /// <summary>
      /// 依赖注入作用范围
      /// 2017/05/16
      /// </summary>
      public class NinjectDependencyScope : IDependencyScope
      {
            private IResolutionRoot resolver;

            internal NinjectDependencyScope(IResolutionRoot resolver)
            {
                  Contract.Assert(resolver != null);
                  this.resolver = resolver;
            }

            public void Dispose()
            {
                  resolver = null;
            }

            public object GetService(Type serviceType)
            {
                  return resolver.TryGet(serviceType);
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                  return resolver.GetAll(serviceType);
            }
      }
}