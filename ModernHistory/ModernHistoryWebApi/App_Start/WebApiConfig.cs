using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ModernHistoryWebApi.Dependencys;
using ModernHistoryWebApi.ExceptionDeal;

namespace ModernHistoryWebApi
{
      public static class WebApiConfig
      {
            public static void Register(HttpConfiguration config)
            {
                  // Web API 配置和服务
                  //注册依赖注入容器
                  config.DependencyResolver = new NinjectDependencyResolver(new Ninject.StandardKernel());
                  // Web API 路由
                  config.MapHttpAttributeRoutes();

                  config.Routes.MapHttpRoute(
                      name: "DefaultApi",
                      routeTemplate: "api/{controller}/{action}/{id}",
                      defaults: new { id = RouteParameter.Optional }
                  );
                  //清除xml序列化，因为我们的实体类没有加上序列化特性，但是Google浏览器默认是xml，
                  GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
                  //异常处理器
                  config.Filters.Add(new CustomerExceptionFilterAttribute());
            }
      }
}
