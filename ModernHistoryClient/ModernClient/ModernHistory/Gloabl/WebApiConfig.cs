using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernHistory.Gloabl
{
    /// <summary>
    /// Web api配置类
    /// 2017/07/10 fhr
    /// </summary>
     public class WebApiConfig
     {
         /// <summary>
         /// web服务基地址
         /// </summary>
         public static readonly string WEBAPI_BASE_URL = "http://localhost:57759/api";
         /// <summary>
         /// 名人图片基地址
         /// </summary>
         public static readonly string WEBAPI_BASE_PERSON_PICURE = "http://localhost:57759/api/Image/GetPersonImg";
         /// <summary>
         /// 事件图片基地址
         /// </summary>
         public static readonly string WEBAPI_BASE_EVENT_PICURE = "http://localhost:57759/api/Image/GetEventImg";

     }
}
