using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ModernHistoryWebApi.ExceptionDeal
{
      /// <summary>
      /// Api自定义异常，主要用于API错误处理
      /// 2017/07/02 fhr
      /// </summary>
      public class CustomerApiException:Exception
      {
            //异常发生后返回的http响应码
            public  HttpStatusCode StatusCode { get; set; }
            //错误标识（业务上的）
            public int Code { get; set; }
            //message自带

            public CustomerApiException(HttpStatusCode statusCode,int code,string message)
                  :base(message)
            {
                  this.StatusCode = statusCode;
                  this.Code = code;
            }
            public CustomerApiException(HttpStatusCode statusCode, string message)
                 : this(HttpStatusCode.InternalServerError, 1, message)
            {
            }
            public CustomerApiException(int code, string message)
                 : this(HttpStatusCode.InternalServerError, code, message)
            {
            }
            public CustomerApiException(string message)
              : this(HttpStatusCode.InternalServerError, 1, message)
            {
            }
      }
}