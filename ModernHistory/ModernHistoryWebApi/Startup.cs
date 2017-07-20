using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using ModernHistoryWebApi.OAuth;
using Owin;

[assembly: OwinStartup(typeof(ModernHistoryWebApi.Startup))]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ModernHistoryWebApi
{
      /// <summary>
      /// OWIN 应用程序配置类
      /// </summary>
      public class Startup
      {
            //将配置对象作为静态属性，方便其他地方引用配置
            public static HttpConfiguration HttpConfiguration { get; private set; }

            public void Configuration(IAppBuilder app)
            {
                  // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
                  //数据库初始化
                  System.Data.Entity.Database.SetInitializer(new Fhr.ModernHistory.Repositorys.Contexts.SampleData());
                  //实例化配置对象
                  HttpConfiguration = new HttpConfiguration();
                  //时间来不及 暂时不配置OAUTH
                  // ConfigureOAuth(app);
                  //注册所有区域
                  AreaRegistration.RegisterAllAreas();
                  WebApiConfig.Register(HttpConfiguration);
                  FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                  RouteConfig.RegisterRoutes(RouteTable.Routes);
                  BundleConfig.RegisterBundles(BundleTable.Bundles);
                  FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                  app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                  app.UseWebApi(HttpConfiguration);
                  //Swagger手动配置
                  SwaggerConfig.Register();
            }
            /// <summary>
            /// 配置OAuth
            /// </summary>
            /// <param name="app"></param>
            private void ConfigureOAuth(IAppBuilder app)
            {
                  var OAuthOptions = new OAuthAuthorizationServerOptions
                  {
                        AllowInsecureHttp = true,
                        AuthenticationMode = AuthenticationMode.Active,
                        TokenEndpointPath = new PathString("/api/token"), //获取 access_token授权服务请求地址
                    //    AuthorizeEndpointPath = new PathString("/authorize"), //获取 authorization_code授权服务请求地址
                        AccessTokenExpireTimeSpan = TimeSpan.FromHours(12), //access_token过期时间
                        Provider = new OpenAuthorizationServerProvider(), //access_token 相关授权服务
                        RefreshTokenProvider = new OpenRefreshTokenProvider() //refresh_token 授权服务
                  };
                  app.UseOAuthBearerTokens(OAuthOptions); //表示 token_type 使用 bearer 方式
                  app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            }
      }
}
