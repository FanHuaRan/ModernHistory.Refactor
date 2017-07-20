using System.Web.Http;
using WebActivatorEx;
using ModernHistoryWebApi;
using Swashbuckle.Application;
using System;
//使用OWIN配置需要注释掉此行 然后再Starup.cs中手动调用Register方法
//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")] 
namespace ModernHistoryWebApi
{
      /// <summary>
      /// Swagger API文档配置类
      /// 2017/07/05 
      /// </summary>
      public class SwaggerConfig
      {
            public static void Register()
            {
                  var thisAssembly = typeof(SwaggerConfig).Assembly;
                  //GlobalConfiguration.HttpConfiguration
                  Startup.HttpConfiguration
                      .EnableSwagger(c =>
                          {
                                c.SingleApiVersion("v1", "ModernHistoryApi");//名称与xml名称一致
                                c.IncludeXmlComments(GetXmlCommentsPath());
                          })
                      .EnableSwaggerUi(c =>
                          {
                          });
            }
            /// <summary>
            /// 项目输出xml文件路径，与设置输出的必须一致
            /// </summary>
            /// <returns></returns>
            private static string GetXmlCommentsPath()
            {
                  return System.String.Format(@"{0}\bin\ModernHistoryApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
            }
      }
}
