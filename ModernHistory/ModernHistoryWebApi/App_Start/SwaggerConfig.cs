using System.Web.Http;
using WebActivatorEx;
using ModernHistoryWebApi;
using Swashbuckle.Application;
using System;
//ʹ��OWIN������Ҫע�͵����� Ȼ����Starup.cs���ֶ�����Register����
//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")] 
namespace ModernHistoryWebApi
{
      /// <summary>
      /// Swagger API�ĵ�������
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
                                c.SingleApiVersion("v1", "ModernHistoryApi");//������xml����һ��
                                c.IncludeXmlComments(GetXmlCommentsPath());
                          })
                      .EnableSwaggerUi(c =>
                          {
                          });
            }
            /// <summary>
            /// ��Ŀ���xml�ļ�·��������������ı���һ��
            /// </summary>
            /// <returns></returns>
            private static string GetXmlCommentsPath()
            {
                  return System.String.Format(@"{0}\bin\ModernHistoryApi.xml", System.AppDomain.CurrentDomain.BaseDirectory);
            }
      }
}
